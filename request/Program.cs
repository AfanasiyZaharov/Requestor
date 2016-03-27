using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libs;

namespace request
{
    public class UseStream
    {
        private Stream mainStream;
        public UseStream(Stream responseStream)
        {
            Console.WriteLine("got a Stream");
            mainStream = responseStream;
        }
        public void WriteStream()
        {
            StreamReader Writer = new StreamReader(mainStream);
            string streamLine = "";
            var istrue = (streamLine != null);
            while (streamLine != null)
            {
                streamLine = Writer.ReadLine();
                if (streamLine != null)
                    Console.WriteLine(streamLine);
            }
            Console.ReadLine();
        }
    }
    public class Helper
    {
        private List<Command> commands;
        public Helper(List<Command> list)
        {
            commands = list;
        }
        public void getCommands()
        {
            foreach (Command command in commands)
            {
                command.PrintDescription();
            }
            Console.ReadLine();
        }

    }

    public abstract class Command
    {
        protected string cmdArgs;
        public Command(string cmdArgs)
        {
            this.cmdArgs = cmdArgs;
        }
        public abstract Boolean CanExecute();
        public abstract void PrintDescription();

    }
    public class WriteHelpCommand : Command
    {
        public WriteHelpCommand(string com): base (com)
        {
        }
        public static bool CanExecute(string cmdArg)
        {
            return cmdArg.EndsWith("help");
        }
        public override void PrintDescription()
        {
            WriteHelpCommand.PrintHelp();
        }
        public static void PrintHelp()
        {
            Console.WriteLine("use a help");
        }
        public override void Execute()
        {
            WriteHelpCommand.PrintHelp();
            GetRequestCommand.PrintHelp();
        }
    }
    public class GetRequestCommand : Command
    {
        public GetRequestCommand(string com) : base(com)
        {

        }
        public static bool CanExecute(string cmdArg)
        {
            return cmdArg.StartsWith("http:");
        }
        public override void PrintDescription()
        {
            GetRequestCommand.PrintHelp();
        }
        public static void PrintHelp()
        {
            Console.WriteLine("use a get req for url and write the data from it");
        }
        public override void Execute()
        {
            var requestor = new Request(cmdArgs);
            var response = requestor.Get();
            if (response.Data != null)
            {
                var writer = new UseStream(response.Data.GetResponseStream());
                writer.WriteStream();
            }
            else
            {
                Console.WriteLine("error");
            }

        }
    }
    public class CommandManager
    {
        public static Command GetCommandByArg(string arg)
        {
            if (GetRequestCommand.CanExecute(arg))
            {
                return new GetRequestCommand(arg);
            }
            if (WriteHelpCommand.CanExecute(arg))
            {
                return new WriteHelpCommand(arg);
            }
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        
            if (args.Length == 0)
            {
                Console.WriteLine("use an arguments");
                Console.ReadLine();
                return;
            }
            List<Command> commands = new List<Command>();
            commands.Add(new WriteHelpCommand(args[0]));
            commands.Add(new GetRequestCommand(args[0]));
            var p  = new WriteHelpCommand(args[0]);
            p.PrintDescription();
            foreach (var command in commands)
            {
                if (command.CanExecute())
                {
                    command.Execute();
                }
            }

        }
    }
}

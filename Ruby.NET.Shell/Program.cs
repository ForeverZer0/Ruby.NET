using System;
using System.Linq;
using static RubyNET.API;

namespace RubyNET
{
    class Program
    {
        static unsafe void Main(string[] args)
        {
            // For unknown reasons, the first argument gets ignored, so prepend an empty string.
            args = args.Prepend(string.Empty).ToArray();
            
            ruby_init();
            var node = ruby_options(args.Length, args);
            if (ruby_executable_node(node, out var state))
            {
                state = ruby_exec_node(node);
                if (state != 0)
                {
                    // Exception handling
                }
            }

            ruby_cleanup(state);
        }
    }
}
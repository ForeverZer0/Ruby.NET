using System;
using System.Globalization;
using static RubyNET.API;

namespace RubyNET
{
    public static class Ruby
    {
        /// <summary>
        /// Writes the copyright string to the standard output.
        /// </summary>
        public static void ShowCopyright() => ruby_show_copyright();

        /// <summary>
        /// Writes the version string to the standard output.
        /// </summary>
        public static void ShowVersion() => ruby_show_version();

        /// <summary>
        /// Gets the API version for the native Ruby library.
        /// </summary>
        public static Version ApiVersion => ruby_api_version;

        /// <summary>
        /// Gets the version for the native Ruby library.
        /// </summary>
        public static Version Version => ruby_version;

        /// <summary>
        /// Gets the name for the native Ruby engine.
        /// <para>Typically this is always <c>"ruby"</c>.</para>
        /// </summary>
        public static string Engine => ruby_engine;

        /// <summary>
        /// Gets the target platform for the native Ruby library. 
        /// </summary>
        public static string Platform => ruby_platform;

        /// <summary>
        /// Gets the release date for the native Ruby library.
        /// </summary>
        public static DateTime ReleaseDate =>
            DateTime.ParseExact(ruby_release_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

        /// <summary>
        /// Gets a brief description of the native Ruby library.
        /// </summary>
        public static string Description => ruby_description;

        /// <summary>
        /// Evaluates and executed the given string as Ruby code. 
        /// </summary>
        /// <param name="str">A string of Ruby code to execute.</param>
        /// <returns>The result of the execution.</returns>
        public static VALUE Eval(string str) => rb_eval_string(str);

        /// <summary>
        /// Evaluates the executes the given string as Ruby code.
        /// </summary>
        /// <param name="str">A string of Ruby code to execute.</param>
        /// <param name="state"><c>0</c> if code executed successfully, otherwise will be a non-zero number.</param>
        /// <returns>The result of the execution.</returns>
        public static VALUE EvalProtect(string str, out int state) => rb_eval_string_protect(str, out state);

        /// <summary>
        /// Emits a warning message to the standard output stream.
        /// </summary>
        /// <param name="message">The warning message to display.</param>
        public static void Warn(string message) => rb_warn(message);

        /// <summary>
        /// Gets the Ruby standard input stream as a <see cref="VALUE"/>.
        /// </summary>
        public static VALUE StandardInput => rb_stdin;

        /// <summary>
        /// Gets the Ruby standard output stream as a <see cref="VALUE"/>.
        /// </summary>
        public static VALUE StandardOutput => rb_stdout;

        /// <summary>
        /// Gets the Ruby standard error stream as a <see cref="VALUE"/>.
        /// </summary>
        public static VALUE StandardError => rb_stderr;
    }
}
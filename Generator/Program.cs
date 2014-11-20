using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace org.pescuma.sharpdecorators.generator
{
	internal class Program
	{
		private static StringBuilder builder;

		private static void Main(string[] args)
		{
			builder = new StringBuilder();

			BuildFile(@"..\..\..\SharpDecorators\ActionDecorators.cs", BuildAction);

			builder = new StringBuilder();

			BuildFile(@"..\..\..\SharpDecorators\FuncDecorators.cs", BuildFunc);
		}

		private static void BuildFile(string actionsFile, Action<int> blockBuilder)
		{
			builder.Append("using System;\n");
			builder.Append("using System.Collections.Concurrent;\n");
			builder.Append("using System.Collections.Generic;\n");
			builder.Append("using System.Diagnostics;\n");
			builder.Append("using System.Linq;\n");
			builder.Append("\n");
			builder.Append("namespace org.pescuma.sharpdecorators\n");
			builder.Append("{\n");

			for (int i = 0; i < 10; i++)
				blockBuilder(i);

			builder.Append("}");

			File.WriteAllText(actionsFile, builder.ToString());
		}

		private static void BuildAction()
		{
			builder.Append("	public class ActionDecorator\n");
			builder.Append("	{\n");
			builder.Append("		private readonly ConcurrentQueue<Action<Action>> decorators = new ConcurrentQueue<Action<Action>>();\n");
			builder.Append("\n");
			builder.Append("		public void Add(Action<Action> decorator)\n");
			builder.Append("		{\n");
			builder.Append("			decorators.Enqueue(decorator);\n");
			builder.Append("		}\n");
			builder.Append("\n");
			builder.Append("		[DebuggerStepThrough]\n");
			builder.Append("		public void Call(Action code)\n");
			builder.Append("		{\n");
			builder.Append("			var blocks = decorators.ToList();\n");
			builder.Append("			blocks.Add(n => code());\n");
			builder.Append("\n");
			builder.Append("			ExecuteNext(blocks, 0);\n");
			builder.Append("		}\n");
			builder.Append("\n");
			builder.Append("		[DebuggerStepThrough]\n");
			builder.Append("		private void ExecuteNext(List<Action<Action>> blocks, int current)\n");
			builder.Append("		{\n");
			builder.Append("			blocks[current](() => ExecuteNext(blocks, current + 1));\n");
			builder.Append("		}\n");
			builder.Append("	}\n");
		}

		private static void BuildAction(int i)
		{
			if (i == 0)
			{
				BuildAction();
				return;
			}

			builder.Append("\n");
			builder.Append("	public class ActionDecorator<" + Create(i, "T{0}") + ">\n");
			builder.Append("	{\n");
			builder.Append("		private readonly ConcurrentQueue<Action<Action<" + Create(i, "T{0}") + ">, " + Create(i, "T{0}")
			               + ">> decorators = new ConcurrentQueue<Action<Action<" + Create(i, "T{0}") + ">, " + Create(i, "T{0}") + ">>();\n");
			builder.Append("\n");
			builder.Append("		public void Add(Action<Action<" + Create(i, "T{0}") + ">, " + Create(i, "T{0}") + "> decorator)\n");
			builder.Append("		{\n");
			builder.Append("			decorators.Enqueue(decorator);\n");
			builder.Append("		}\n");
			builder.Append("\n");
			builder.Append("		[DebuggerStepThrough]\n");
			builder.Append("		public void Call(" + Create(i, "T{0} arg{0}") + ", Action<" + Create(i, "T{0}") + "> code)\n");
			builder.Append("		{\n");
			builder.Append("			var blocks = decorators.ToList();\n");
			builder.Append("			blocks.Add((n, " + Create(i, "a{0}") + ") => code(" + Create(i, "a{0}") + "));\n");
			builder.Append("\n");
			builder.Append("			ExecuteNext(blocks, 0, " + Create(i, "arg{0}") + ");\n");
			builder.Append("		}\n");
			builder.Append("\n");
			builder.Append("		[DebuggerStepThrough]\n");
			builder.Append("		private void ExecuteNext(List<Action<Action<" + Create(i, "T{0}") + ">, " + Create(i, "T{0}")
			               + ">> blocks, int current, " + Create(i, "T{0} arg{0}") + ")\n");
			builder.Append("		{\n");
			builder.Append("			blocks[current]((" + Create(i, "a{0}") + ") => ExecuteNext(blocks, current + 1, " + Create(i, "a{0}") + "), "
			               + Create(i, "arg{0}") + ");\n");
			builder.Append("		}\n");
			builder.Append("	}\n");
		}

		private static void BuildFunc()
		{
			builder.Append("	public class FuncDecorator<TResult>\n");
			builder.Append("	{\n");
			builder.Append(
				"		private readonly ConcurrentQueue<Func<Func<TResult>, TResult>> decorators = new ConcurrentQueue<Func<Func<TResult>, TResult>>();\n");
			builder.Append("\n");
			builder.Append("		public void Add(Func<Func<TResult>, TResult> decorator)\n");
			builder.Append("		{\n");
			builder.Append("			decorators.Enqueue(decorator);\n");
			builder.Append("		}\n");
			builder.Append("\n");
			builder.Append("		[DebuggerStepThrough]\n");
			builder.Append("		public TResult Call(Func<TResult> code)\n");
			builder.Append("		{\n");
			builder.Append("			var blocks = decorators.ToList();\n");
			builder.Append("			blocks.Add(n => code());\n");
			builder.Append("\n");
			builder.Append("			return ExecuteNext(blocks, 0);\n");
			builder.Append("		}\n");
			builder.Append("\n");
			builder.Append("		[DebuggerStepThrough]\n");
			builder.Append("		private TResult ExecuteNext(List<Func<Func<TResult>, TResult>> blocks, int current)\n");
			builder.Append("		{\n");
			builder.Append("			return blocks[current](() => ExecuteNext(blocks, current + 1));\n");
			builder.Append("		}\n");
			builder.Append("	}\n");
		}

		private static void BuildFunc(int i)
		{
			if (i == 0)
			{
				BuildFunc();
				return;
			}

			builder.Append("\n");
			builder.Append("	public class FuncDecorator<" + Create(i, "T{0}") + ", TResult>\n");
			builder.Append("	{\n");
			builder.Append("		private readonly ConcurrentQueue<Func<Func<" + Create(i, "T{0}") + ", TResult>, " + Create(i, "T{0}")
			               + ", TResult>> decorators = new ConcurrentQueue<Func<Func<" + Create(i, "T{0}") + ", TResult>, " + Create(i, "T{0}")
			               + ", TResult>>();\n");
			builder.Append("\n");
			builder.Append("		public void Add(Func<Func<" + Create(i, "T{0}") + ", TResult>, " + Create(i, "T{0}") + ", TResult> decorator)\n");
			builder.Append("		{\n");
			builder.Append("			decorators.Enqueue(decorator);\n");
			builder.Append("		}\n");
			builder.Append("\n");
			builder.Append("		[DebuggerStepThrough]\n");
			builder.Append("		public TResult Call(" + Create(i, "T{0} arg{0}") + ", Func<" + Create(i, "T{0}") + ", TResult> code)\n");
			builder.Append("		{\n");
			builder.Append("			var blocks = decorators.ToList();\n");
			builder.Append("			blocks.Add((n, " + Create(i, "a{0}") + ") => code(" + Create(i, "a{0}") + "));\n");
			builder.Append("\n");
			builder.Append("			return ExecuteNext(blocks, 0, " + Create(i, "arg{0}") + ");\n");
			builder.Append("		}\n");
			builder.Append("\n");
			builder.Append("		[DebuggerStepThrough]\n");
			builder.Append("		private TResult ExecuteNext(List<Func<Func<" + Create(i, "T{0}") + ", TResult>, " + Create(i, "T{0}")
			               + ", TResult>> blocks, int current, " + Create(i, "T{0} arg{0}") + ")\n");
			builder.Append("		{\n");
			builder.Append("			return blocks[current]((" + Create(i, "a{0}") + ") => ExecuteNext(blocks, current + 1, " + Create(i, "a{0}") + "), "
			               + Create(i, "arg{0}") + ");\n");
			builder.Append("		}\n");
			builder.Append("	}\n");
		}

		private static string Create(int count, string format)
		{
			return string.Join(", ", Range(1, count)
				.Select(i => string.Format(format, i)));
		}

		private static IEnumerable<int> Range(int start, int elements)
		{
			for (int i = 0; i < elements; i++)
				yield return i + start;
		}
	}
}

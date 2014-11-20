using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace org.pescuma.sharpdecorators
{
	public class FuncDecorator<TResult>
	{
		private readonly ConcurrentQueue<Func<Func<TResult>, TResult>> decorators = new ConcurrentQueue<Func<Func<TResult>, TResult>>();

		public void Add(Func<Func<TResult>, TResult> decorator)
		{
			decorators.Enqueue(decorator);
		}

		[DebuggerStepThrough]
		public TResult Call(Func<TResult> code)
		{
			var blocks = decorators.ToList();
			blocks.Add(n => code());

			return ExecuteNext(blocks, 0);
		}

		[DebuggerStepThrough]
		private TResult ExecuteNext(List<Func<Func<TResult>, TResult>> blocks, int current)
		{
			return blocks[current](() => ExecuteNext(blocks, current + 1));
		}
	}

	public class FuncDecorator<T1, TResult>
	{
		private readonly ConcurrentQueue<Func<Func<T1, TResult>, T1, TResult>> decorators = new ConcurrentQueue<Func<Func<T1, TResult>, T1, TResult>>();

		public void Add(Func<Func<T1, TResult>, T1, TResult> decorator)
		{
			decorators.Enqueue(decorator);
		}

		[DebuggerStepThrough]
		public TResult Call(T1 arg1, Func<T1, TResult> code)
		{
			var blocks = decorators.ToList();
			blocks.Add((n, a1) => code(a1));

			return ExecuteNext(blocks, 0, arg1);
		}

		[DebuggerStepThrough]
		private TResult ExecuteNext(List<Func<Func<T1, TResult>, T1, TResult>> blocks, int current, T1 arg1)
		{
			return blocks[current]((a1) => ExecuteNext(blocks, current + 1, a1), arg1);
		}
	}

	public class FuncDecorator<T1, T2, TResult>
	{
		private readonly ConcurrentQueue<Func<Func<T1, T2, TResult>, T1, T2, TResult>> decorators = new ConcurrentQueue<Func<Func<T1, T2, TResult>, T1, T2, TResult>>();

		public void Add(Func<Func<T1, T2, TResult>, T1, T2, TResult> decorator)
		{
			decorators.Enqueue(decorator);
		}

		[DebuggerStepThrough]
		public TResult Call(T1 arg1, T2 arg2, Func<T1, T2, TResult> code)
		{
			var blocks = decorators.ToList();
			blocks.Add((n, a1, a2) => code(a1, a2));

			return ExecuteNext(blocks, 0, arg1, arg2);
		}

		[DebuggerStepThrough]
		private TResult ExecuteNext(List<Func<Func<T1, T2, TResult>, T1, T2, TResult>> blocks, int current, T1 arg1, T2 arg2)
		{
			return blocks[current]((a1, a2) => ExecuteNext(blocks, current + 1, a1, a2), arg1, arg2);
		}
	}

	public class FuncDecorator<T1, T2, T3, TResult>
	{
		private readonly ConcurrentQueue<Func<Func<T1, T2, T3, TResult>, T1, T2, T3, TResult>> decorators = new ConcurrentQueue<Func<Func<T1, T2, T3, TResult>, T1, T2, T3, TResult>>();

		public void Add(Func<Func<T1, T2, T3, TResult>, T1, T2, T3, TResult> decorator)
		{
			decorators.Enqueue(decorator);
		}

		[DebuggerStepThrough]
		public TResult Call(T1 arg1, T2 arg2, T3 arg3, Func<T1, T2, T3, TResult> code)
		{
			var blocks = decorators.ToList();
			blocks.Add((n, a1, a2, a3) => code(a1, a2, a3));

			return ExecuteNext(blocks, 0, arg1, arg2, arg3);
		}

		[DebuggerStepThrough]
		private TResult ExecuteNext(List<Func<Func<T1, T2, T3, TResult>, T1, T2, T3, TResult>> blocks, int current, T1 arg1, T2 arg2, T3 arg3)
		{
			return blocks[current]((a1, a2, a3) => ExecuteNext(blocks, current + 1, a1, a2, a3), arg1, arg2, arg3);
		}
	}

	public class FuncDecorator<T1, T2, T3, T4, TResult>
	{
		private readonly ConcurrentQueue<Func<Func<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>> decorators = new ConcurrentQueue<Func<Func<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>>();

		public void Add(Func<Func<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult> decorator)
		{
			decorators.Enqueue(decorator);
		}

		[DebuggerStepThrough]
		public TResult Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, Func<T1, T2, T3, T4, TResult> code)
		{
			var blocks = decorators.ToList();
			blocks.Add((n, a1, a2, a3, a4) => code(a1, a2, a3, a4));

			return ExecuteNext(blocks, 0, arg1, arg2, arg3, arg4);
		}

		[DebuggerStepThrough]
		private TResult ExecuteNext(List<Func<Func<T1, T2, T3, T4, TResult>, T1, T2, T3, T4, TResult>> blocks, int current, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			return blocks[current]((a1, a2, a3, a4) => ExecuteNext(blocks, current + 1, a1, a2, a3, a4), arg1, arg2, arg3, arg4);
		}
	}

	public class FuncDecorator<T1, T2, T3, T4, T5, TResult>
	{
		private readonly ConcurrentQueue<Func<Func<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult>> decorators = new ConcurrentQueue<Func<Func<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult>>();

		public void Add(Func<Func<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult> decorator)
		{
			decorators.Enqueue(decorator);
		}

		[DebuggerStepThrough]
		public TResult Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Func<T1, T2, T3, T4, T5, TResult> code)
		{
			var blocks = decorators.ToList();
			blocks.Add((n, a1, a2, a3, a4, a5) => code(a1, a2, a3, a4, a5));

			return ExecuteNext(blocks, 0, arg1, arg2, arg3, arg4, arg5);
		}

		[DebuggerStepThrough]
		private TResult ExecuteNext(List<Func<Func<T1, T2, T3, T4, T5, TResult>, T1, T2, T3, T4, T5, TResult>> blocks, int current, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			return blocks[current]((a1, a2, a3, a4, a5) => ExecuteNext(blocks, current + 1, a1, a2, a3, a4, a5), arg1, arg2, arg3, arg4, arg5);
		}
	}

	public class FuncDecorator<T1, T2, T3, T4, T5, T6, TResult>
	{
		private readonly ConcurrentQueue<Func<Func<T1, T2, T3, T4, T5, T6, TResult>, T1, T2, T3, T4, T5, T6, TResult>> decorators = new ConcurrentQueue<Func<Func<T1, T2, T3, T4, T5, T6, TResult>, T1, T2, T3, T4, T5, T6, TResult>>();

		public void Add(Func<Func<T1, T2, T3, T4, T5, T6, TResult>, T1, T2, T3, T4, T5, T6, TResult> decorator)
		{
			decorators.Enqueue(decorator);
		}

		[DebuggerStepThrough]
		public TResult Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, Func<T1, T2, T3, T4, T5, T6, TResult> code)
		{
			var blocks = decorators.ToList();
			blocks.Add((n, a1, a2, a3, a4, a5, a6) => code(a1, a2, a3, a4, a5, a6));

			return ExecuteNext(blocks, 0, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		[DebuggerStepThrough]
		private TResult ExecuteNext(List<Func<Func<T1, T2, T3, T4, T5, T6, TResult>, T1, T2, T3, T4, T5, T6, TResult>> blocks, int current, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			return blocks[current]((a1, a2, a3, a4, a5, a6) => ExecuteNext(blocks, current + 1, a1, a2, a3, a4, a5, a6), arg1, arg2, arg3, arg4, arg5, arg6);
		}
	}

	public class FuncDecorator<T1, T2, T3, T4, T5, T6, T7, TResult>
	{
		private readonly ConcurrentQueue<Func<Func<T1, T2, T3, T4, T5, T6, T7, TResult>, T1, T2, T3, T4, T5, T6, T7, TResult>> decorators = new ConcurrentQueue<Func<Func<T1, T2, T3, T4, T5, T6, T7, TResult>, T1, T2, T3, T4, T5, T6, T7, TResult>>();

		public void Add(Func<Func<T1, T2, T3, T4, T5, T6, T7, TResult>, T1, T2, T3, T4, T5, T6, T7, TResult> decorator)
		{
			decorators.Enqueue(decorator);
		}

		[DebuggerStepThrough]
		public TResult Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, Func<T1, T2, T3, T4, T5, T6, T7, TResult> code)
		{
			var blocks = decorators.ToList();
			blocks.Add((n, a1, a2, a3, a4, a5, a6, a7) => code(a1, a2, a3, a4, a5, a6, a7));

			return ExecuteNext(blocks, 0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		[DebuggerStepThrough]
		private TResult ExecuteNext(List<Func<Func<T1, T2, T3, T4, T5, T6, T7, TResult>, T1, T2, T3, T4, T5, T6, T7, TResult>> blocks, int current, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			return blocks[current]((a1, a2, a3, a4, a5, a6, a7) => ExecuteNext(blocks, current + 1, a1, a2, a3, a4, a5, a6, a7), arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}
	}

	public class FuncDecorator<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
	{
		private readonly ConcurrentQueue<Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, TResult>> decorators = new ConcurrentQueue<Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, TResult>>();

		public void Add(Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, TResult> decorator)
		{
			decorators.Enqueue(decorator);
		}

		[DebuggerStepThrough]
		public TResult Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> code)
		{
			var blocks = decorators.ToList();
			blocks.Add((n, a1, a2, a3, a4, a5, a6, a7, a8) => code(a1, a2, a3, a4, a5, a6, a7, a8));

			return ExecuteNext(blocks, 0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		[DebuggerStepThrough]
		private TResult ExecuteNext(List<Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, TResult>> blocks, int current, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			return blocks[current]((a1, a2, a3, a4, a5, a6, a7, a8) => ExecuteNext(blocks, current + 1, a1, a2, a3, a4, a5, a6, a7, a8), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}
	}

	public class FuncDecorator<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
	{
		private readonly ConcurrentQueue<Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>> decorators = new ConcurrentQueue<Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>();

		public void Add(Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> decorator)
		{
			decorators.Enqueue(decorator);
		}

		[DebuggerStepThrough]
		public TResult Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> code)
		{
			var blocks = decorators.ToList();
			blocks.Add((n, a1, a2, a3, a4, a5, a6, a7, a8, a9) => code(a1, a2, a3, a4, a5, a6, a7, a8, a9));

			return ExecuteNext(blocks, 0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		[DebuggerStepThrough]
		private TResult ExecuteNext(List<Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>> blocks, int current, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			return blocks[current]((a1, a2, a3, a4, a5, a6, a7, a8, a9) => ExecuteNext(blocks, current + 1, a1, a2, a3, a4, a5, a6, a7, a8, a9), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}
	}
}
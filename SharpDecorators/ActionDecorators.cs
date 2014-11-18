using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace org.pescuma.sharpdecorators
{
	public class ActionDecorator
	{
		private readonly ConcurrentQueue<Action<Action>> decorators = new ConcurrentQueue<Action<Action>>();

		public void Add(Action<Action> decorator)
		{
			decorators.Enqueue(decorator);
		}

		public void Call(Action code)
		{
			var blocks = decorators.ToList();
			blocks.Add(n => code());

			ExecuteNext(blocks, 0);
		}

		private void ExecuteNext(List<Action<Action>> blocks, int current)
		{
			blocks[current](() => ExecuteNext(blocks, current + 1));
		}
	}

	public class ActionDecorator<T1>
	{
		private readonly ConcurrentQueue<Action<Action<T1>, T1>> decorators = new ConcurrentQueue<Action<Action<T1>, T1>>();

		public void Add(Action<Action<T1>, T1> decorator)
		{
			decorators.Enqueue(decorator);
		}

		public void Call(T1 arg1, Action<T1> code)
		{
			var blocks = decorators.ToList();
			blocks.Add((n, a1) => code(a1));

			ExecuteNext(blocks, 0, arg1);
		}

		private void ExecuteNext(List<Action<Action<T1>, T1>> blocks, int current, T1 arg1)
		{
			blocks[current]((a1) => ExecuteNext(blocks, current + 1, a1), arg1);
		}
	}

	public class ActionDecorator<T1, T2>
	{
		private readonly ConcurrentQueue<Action<Action<T1, T2>, T1, T2>> decorators = new ConcurrentQueue<Action<Action<T1, T2>, T1, T2>>();

		public void Add(Action<Action<T1, T2>, T1, T2> decorator)
		{
			decorators.Enqueue(decorator);
		}

		public void Call(T1 arg1, T2 arg2, Action<T1, T2> code)
		{
			var blocks = decorators.ToList();
			blocks.Add((n, a1, a2) => code(a1, a2));

			ExecuteNext(blocks, 0, arg1, arg2);
		}

		private void ExecuteNext(List<Action<Action<T1, T2>, T1, T2>> blocks, int current, T1 arg1, T2 arg2)
		{
			blocks[current]((a1, a2) => ExecuteNext(blocks, current + 1, a1, a2), arg1, arg2);
		}
	}

	public class ActionDecorator<T1, T2, T3>
	{
		private readonly ConcurrentQueue<Action<Action<T1, T2, T3>, T1, T2, T3>> decorators = new ConcurrentQueue<Action<Action<T1, T2, T3>, T1, T2, T3>>();

		public void Add(Action<Action<T1, T2, T3>, T1, T2, T3> decorator)
		{
			decorators.Enqueue(decorator);
		}

		public void Call(T1 arg1, T2 arg2, T3 arg3, Action<T1, T2, T3> code)
		{
			var blocks = decorators.ToList();
			blocks.Add((n, a1, a2, a3) => code(a1, a2, a3));

			ExecuteNext(blocks, 0, arg1, arg2, arg3);
		}

		private void ExecuteNext(List<Action<Action<T1, T2, T3>, T1, T2, T3>> blocks, int current, T1 arg1, T2 arg2, T3 arg3)
		{
			blocks[current]((a1, a2, a3) => ExecuteNext(blocks, current + 1, a1, a2, a3), arg1, arg2, arg3);
		}
	}

	public class ActionDecorator<T1, T2, T3, T4>
	{
		private readonly ConcurrentQueue<Action<Action<T1, T2, T3, T4>, T1, T2, T3, T4>> decorators = new ConcurrentQueue<Action<Action<T1, T2, T3, T4>, T1, T2, T3, T4>>();

		public void Add(Action<Action<T1, T2, T3, T4>, T1, T2, T3, T4> decorator)
		{
			decorators.Enqueue(decorator);
		}

		public void Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, Action<T1, T2, T3, T4> code)
		{
			var blocks = decorators.ToList();
			blocks.Add((n, a1, a2, a3, a4) => code(a1, a2, a3, a4));

			ExecuteNext(blocks, 0, arg1, arg2, arg3, arg4);
		}

		private void ExecuteNext(List<Action<Action<T1, T2, T3, T4>, T1, T2, T3, T4>> blocks, int current, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			blocks[current]((a1, a2, a3, a4) => ExecuteNext(blocks, current + 1, a1, a2, a3, a4), arg1, arg2, arg3, arg4);
		}
	}

	public class ActionDecorator<T1, T2, T3, T4, T5>
	{
		private readonly ConcurrentQueue<Action<Action<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>> decorators = new ConcurrentQueue<Action<Action<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>>();

		public void Add(Action<Action<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5> decorator)
		{
			decorators.Enqueue(decorator);
		}

		public void Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Action<T1, T2, T3, T4, T5> code)
		{
			var blocks = decorators.ToList();
			blocks.Add((n, a1, a2, a3, a4, a5) => code(a1, a2, a3, a4, a5));

			ExecuteNext(blocks, 0, arg1, arg2, arg3, arg4, arg5);
		}

		private void ExecuteNext(List<Action<Action<T1, T2, T3, T4, T5>, T1, T2, T3, T4, T5>> blocks, int current, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			blocks[current]((a1, a2, a3, a4, a5) => ExecuteNext(blocks, current + 1, a1, a2, a3, a4, a5), arg1, arg2, arg3, arg4, arg5);
		}
	}

	public class ActionDecorator<T1, T2, T3, T4, T5, T6>
	{
		private readonly ConcurrentQueue<Action<Action<T1, T2, T3, T4, T5, T6>, T1, T2, T3, T4, T5, T6>> decorators = new ConcurrentQueue<Action<Action<T1, T2, T3, T4, T5, T6>, T1, T2, T3, T4, T5, T6>>();

		public void Add(Action<Action<T1, T2, T3, T4, T5, T6>, T1, T2, T3, T4, T5, T6> decorator)
		{
			decorators.Enqueue(decorator);
		}

		public void Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, Action<T1, T2, T3, T4, T5, T6> code)
		{
			var blocks = decorators.ToList();
			blocks.Add((n, a1, a2, a3, a4, a5, a6) => code(a1, a2, a3, a4, a5, a6));

			ExecuteNext(blocks, 0, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		private void ExecuteNext(List<Action<Action<T1, T2, T3, T4, T5, T6>, T1, T2, T3, T4, T5, T6>> blocks, int current, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			blocks[current]((a1, a2, a3, a4, a5, a6) => ExecuteNext(blocks, current + 1, a1, a2, a3, a4, a5, a6), arg1, arg2, arg3, arg4, arg5, arg6);
		}
	}

	public class ActionDecorator<T1, T2, T3, T4, T5, T6, T7>
	{
		private readonly ConcurrentQueue<Action<Action<T1, T2, T3, T4, T5, T6, T7>, T1, T2, T3, T4, T5, T6, T7>> decorators = new ConcurrentQueue<Action<Action<T1, T2, T3, T4, T5, T6, T7>, T1, T2, T3, T4, T5, T6, T7>>();

		public void Add(Action<Action<T1, T2, T3, T4, T5, T6, T7>, T1, T2, T3, T4, T5, T6, T7> decorator)
		{
			decorators.Enqueue(decorator);
		}

		public void Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, Action<T1, T2, T3, T4, T5, T6, T7> code)
		{
			var blocks = decorators.ToList();
			blocks.Add((n, a1, a2, a3, a4, a5, a6, a7) => code(a1, a2, a3, a4, a5, a6, a7));

			ExecuteNext(blocks, 0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		private void ExecuteNext(List<Action<Action<T1, T2, T3, T4, T5, T6, T7>, T1, T2, T3, T4, T5, T6, T7>> blocks, int current, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			blocks[current]((a1, a2, a3, a4, a5, a6, a7) => ExecuteNext(blocks, current + 1, a1, a2, a3, a4, a5, a6, a7), arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}
	}

	public class ActionDecorator<T1, T2, T3, T4, T5, T6, T7, T8>
	{
		private readonly ConcurrentQueue<Action<Action<T1, T2, T3, T4, T5, T6, T7, T8>, T1, T2, T3, T4, T5, T6, T7, T8>> decorators = new ConcurrentQueue<Action<Action<T1, T2, T3, T4, T5, T6, T7, T8>, T1, T2, T3, T4, T5, T6, T7, T8>>();

		public void Add(Action<Action<T1, T2, T3, T4, T5, T6, T7, T8>, T1, T2, T3, T4, T5, T6, T7, T8> decorator)
		{
			decorators.Enqueue(decorator);
		}

		public void Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, Action<T1, T2, T3, T4, T5, T6, T7, T8> code)
		{
			var blocks = decorators.ToList();
			blocks.Add((n, a1, a2, a3, a4, a5, a6, a7, a8) => code(a1, a2, a3, a4, a5, a6, a7, a8));

			ExecuteNext(blocks, 0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		private void ExecuteNext(List<Action<Action<T1, T2, T3, T4, T5, T6, T7, T8>, T1, T2, T3, T4, T5, T6, T7, T8>> blocks, int current, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			blocks[current]((a1, a2, a3, a4, a5, a6, a7, a8) => ExecuteNext(blocks, current + 1, a1, a2, a3, a4, a5, a6, a7, a8), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}
	}

	public class ActionDecorator<T1, T2, T3, T4, T5, T6, T7, T8, T9>
	{
		private readonly ConcurrentQueue<Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T1, T2, T3, T4, T5, T6, T7, T8, T9>> decorators = new ConcurrentQueue<Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T1, T2, T3, T4, T5, T6, T7, T8, T9>>();

		public void Add(Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T1, T2, T3, T4, T5, T6, T7, T8, T9> decorator)
		{
			decorators.Enqueue(decorator);
		}

		public void Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> code)
		{
			var blocks = decorators.ToList();
			blocks.Add((n, a1, a2, a3, a4, a5, a6, a7, a8, a9) => code(a1, a2, a3, a4, a5, a6, a7, a8, a9));

			ExecuteNext(blocks, 0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		private void ExecuteNext(List<Action<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T1, T2, T3, T4, T5, T6, T7, T8, T9>> blocks, int current, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			blocks[current]((a1, a2, a3, a4, a5, a6, a7, a8, a9) => ExecuteNext(blocks, current + 1, a1, a2, a3, a4, a5, a6, a7, a8, a9), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}
	}
}
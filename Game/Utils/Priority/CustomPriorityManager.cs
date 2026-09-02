using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.Priority
{
	// Token: 0x02004709 RID: 18185
	public class CustomPriorityManager<T> : IClear where T : struct, Enum
	{
		// Token: 0x0602F487 RID: 193671 RVA: 0x00B351BC File Offset: 0x00B333BC
		[NullableContext(1)]
		private unsafe void LogInternal(string message, ELogLevel logLevel = ELogLevel.Error)
		{
			if (ModelBase<SundryModel>.Instance.GetModuleDebugLevel("CustomPriorityManager") < (int)logLevel)
			{
				return;
			}
			switch (logLevel)
			{
			case ELogLevel.Error:
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Container;
				ELogAuthor author = ELogAuthor.XDW;
				string message2 = "[PriorityManager] [" + this.Identifier + "] " + message;
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Registry", this.Registry.Keys.ToList<T>());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Top", this.PriorityQueue.Empty ? null : new T?(this.PriorityQueue.Top));
				instance.Error(module, author, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			case ELogLevel.Warn:
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Container;
				ELogAuthor author2 = ELogAuthor.XDW;
				string message3 = "[PriorityManager] [" + this.Identifier + "] " + message;
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Registry", this.Registry.Keys.ToList<T>());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Top", this.PriorityQueue.Empty ? null : new T?(this.PriorityQueue.Top));
				instance2.Warn(module2, author2, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return;
			}
			case ELogLevel.Info:
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Container;
				ELogAuthor author3 = ELogAuthor.XDW;
				string message4 = "[PriorityManager] [" + this.Identifier + "] " + message;
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Registry", this.Registry.Keys.ToList<T>());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Top", this.PriorityQueue.Empty ? null : new T?(this.PriorityQueue.Top));
				instance3.Info(module3, author3, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0602F488 RID: 193672 RVA: 0x00B353CE File Offset: 0x00B335CE
		[NullableContext(1)]
		public CustomPriorityManager(string identifier)
		{
			this.Identifier = identifier;
			this.PriorityQueue = new PriorityQueue<T>(delegate(T a, T b)
			{
				ICustomPriorityConfigWrapper<T> customPriorityConfigWrapper2;
				ICustomPriorityConfigWrapper<T> customPriorityConfigWrapper = this.Registry.TryGetValue(a, out customPriorityConfigWrapper2) ? customPriorityConfigWrapper2 : null;
				ICustomPriorityConfigWrapper<T> customPriorityConfigWrapper4;
				ICustomPriorityConfigWrapper<T> customPriorityConfigWrapper3 = this.Registry.TryGetValue(b, out customPriorityConfigWrapper4) ? customPriorityConfigWrapper4 : null;
				if (customPriorityConfigWrapper == null || customPriorityConfigWrapper3 == null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 2);
					defaultInterpolatedStringHandler.AppendLiteral("[Compare] config not registered for ");
					defaultInterpolatedStringHandler.AppendFormatted<T>(a);
					defaultInterpolatedStringHandler.AppendLiteral(" or ");
					defaultInterpolatedStringHandler.AppendFormatted<T>(b);
					this.LogInternal(defaultInterpolatedStringHandler.ToStringAndClear(), ELogLevel.Error);
					return 0;
				}
				return customPriorityConfigWrapper.Priority - customPriorityConfigWrapper3.Priority;
			});
		}

		// Token: 0x0602F489 RID: 193673 RVA: 0x00B35400 File Offset: 0x00B33600
		public bool Register(T enumValue, [Nullable(new byte[]
		{
			1,
			0
		})] ICustomPriorityConfig<T> config)
		{
			if (this.Registry.ContainsKey(enumValue))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(42, 1);
				defaultInterpolatedStringHandler.AppendLiteral("[Register] enumValue [");
				defaultInterpolatedStringHandler.AppendFormatted<T>(enumValue);
				defaultInterpolatedStringHandler.AppendLiteral("] already registered");
				this.LogInternal(defaultInterpolatedStringHandler.ToStringAndClear(), ELogLevel.Error);
				return false;
			}
			int priority = config.Priority ?? Convert.ToInt32(enumValue);
			this.Registry[enumValue] = new CustomPriorityConfigWrapper<T>
			{
				Enable = config.Enable,
				Enum = enumValue,
				Priority = priority,
				EnterWrapper = delegate(bool isReentrant, bool isForce, string reason)
				{
					CustomPriorityManager<T> <>4__this = this;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(51, 4);
					defaultInterpolatedStringHandler2.AppendLiteral("[Enter] [Reentrant: ");
					defaultInterpolatedStringHandler2.AppendFormatted<bool>(isReentrant);
					defaultInterpolatedStringHandler2.AppendLiteral("] [Force: ");
					defaultInterpolatedStringHandler2.AppendFormatted<bool>(isForce);
					defaultInterpolatedStringHandler2.AppendLiteral("] [Reason: ");
					defaultInterpolatedStringHandler2.AppendFormatted(reason);
					defaultInterpolatedStringHandler2.AppendLiteral("] [Enum: ");
					defaultInterpolatedStringHandler2.AppendFormatted<T>(enumValue);
					defaultInterpolatedStringHandler2.AppendLiteral("]");
					<>4__this.LogInternal(defaultInterpolatedStringHandler2.ToStringAndClear(), ELogLevel.Info);
					Func<ICustomPriorityCallbackParam, bool> enterCallback = config.EnterCallback;
					return enterCallback != null && enterCallback(new CustomPriorityCallbackParam
					{
						IsReentrant = new bool?(isReentrant),
						IsForce = isForce
					});
				},
				EnterReentrant = config.EnterReentrant,
				ForceEnterCallback = config.ForceEnterCallback,
				ExitWrapper = delegate(bool isForce, string reason)
				{
					CustomPriorityManager<T> <>4__this = this;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(36, 3);
					defaultInterpolatedStringHandler2.AppendLiteral("[Exit] [Force: ");
					defaultInterpolatedStringHandler2.AppendFormatted<bool>(isForce);
					defaultInterpolatedStringHandler2.AppendLiteral("] [Reason: ");
					defaultInterpolatedStringHandler2.AppendFormatted(reason);
					defaultInterpolatedStringHandler2.AppendLiteral("] [Enum: ");
					defaultInterpolatedStringHandler2.AppendFormatted<T>(enumValue);
					defaultInterpolatedStringHandler2.AppendLiteral("]");
					<>4__this.LogInternal(defaultInterpolatedStringHandler2.ToStringAndClear(), ELogLevel.Info);
					Func<ICustomPriorityCallbackParam, bool> exitCallback = config.ExitCallback;
					return exitCallback != null && exitCallback(new CustomPriorityCallbackParam
					{
						IsForce = isForce
					});
				},
				ForceExitCallback = config.ForceExitCallback
			};
			if (config.Enable)
			{
				this.TryEnter(enumValue, "Register");
			}
			return true;
		}

		// Token: 0x0602F48A RID: 193674 RVA: 0x00B3555A File Offset: 0x00B3375A
		public void UnRegister(T enumValue)
		{
			this.TryExit(enumValue, "UnRegister");
			this.Registry.Remove(enumValue);
		}

		// Token: 0x0602F48B RID: 193675 RVA: 0x00B35576 File Offset: 0x00B33776
		public bool ClearObject()
		{
			this.TryExitAll("ClearObject");
			this.Registry.Clear();
			return true;
		}

		// Token: 0x0602F48C RID: 193676 RVA: 0x00B35590 File Offset: 0x00B33790
		public bool TryEnter(T enumValue, [Nullable(1)] string reason = "")
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
			defaultInterpolatedStringHandler.AppendLiteral("[TryEnter] [");
			defaultInterpolatedStringHandler.AppendFormatted(reason);
			defaultInterpolatedStringHandler.AppendLiteral("] [");
			defaultInterpolatedStringHandler.AppendFormatted<T>(enumValue);
			defaultInterpolatedStringHandler.AppendLiteral("]");
			this.LogInternal(defaultInterpolatedStringHandler.ToStringAndClear(), ELogLevel.Info);
			ICustomPriorityConfigWrapper<T> customPriorityConfigWrapper2;
			ICustomPriorityConfigWrapper<T> customPriorityConfigWrapper = this.Registry.TryGetValue(enumValue, out customPriorityConfigWrapper2) ? customPriorityConfigWrapper2 : null;
			if (customPriorityConfigWrapper == null)
			{
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 2);
				defaultInterpolatedStringHandler.AppendLiteral("[TryEnter] [");
				defaultInterpolatedStringHandler.AppendFormatted(reason);
				defaultInterpolatedStringHandler.AppendLiteral("] [");
				defaultInterpolatedStringHandler.AppendFormatted<T>(enumValue);
				defaultInterpolatedStringHandler.AppendLiteral("] not registered");
				this.LogInternal(defaultInterpolatedStringHandler.ToStringAndClear(), ELogLevel.Error);
				return false;
			}
			customPriorityConfigWrapper.Enable = true;
			T? t = this.PriorityQueue.Empty ? null : new T?(this.PriorityQueue.Top);
			if (object.Equals(t, enumValue))
			{
				if (customPriorityConfigWrapper.EnterReentrant.GetValueOrDefault())
				{
					customPriorityConfigWrapper.EnterWrapper(true, false, reason + " [same as top]");
				}
				else if (customPriorityConfigWrapper.ForceEnterCallback.GetValueOrDefault())
				{
					customPriorityConfigWrapper.EnterWrapper(false, true, reason + " [same as top]");
				}
				return false;
			}
			if (this.PriorityQueue.Has(enumValue))
			{
				if (customPriorityConfigWrapper.ForceEnterCallback.GetValueOrDefault())
				{
					customPriorityConfigWrapper.EnterWrapper(false, true, reason + " [lower priority than top]");
				}
				return false;
			}
			this.PriorityQueue.Push(enumValue);
			if (object.Equals(t, this.PriorityQueue.Top))
			{
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(52, 3);
				defaultInterpolatedStringHandler.AppendLiteral("[TryEnter] [");
				defaultInterpolatedStringHandler.AppendFormatted(reason);
				defaultInterpolatedStringHandler.AppendLiteral("] [");
				defaultInterpolatedStringHandler.AppendFormatted<T>(enumValue);
				defaultInterpolatedStringHandler.AppendLiteral("] [with lower priority than current ");
				defaultInterpolatedStringHandler.AppendFormatted<T?>(t);
				defaultInterpolatedStringHandler.AppendLiteral("]");
				this.LogInternal(defaultInterpolatedStringHandler.ToStringAndClear(), ELogLevel.Warn);
				if (customPriorityConfigWrapper.ForceEnterCallback.GetValueOrDefault())
				{
					customPriorityConfigWrapper.EnterWrapper(false, true, reason + " [lower priority than top]");
				}
				return false;
			}
			if (t != null)
			{
				ICustomPriorityConfigWrapper<T> customPriorityConfigWrapper3;
				this.Registry.TryGetValue(t.Value, out customPriorityConfigWrapper3);
				if (customPriorityConfigWrapper3 != null)
				{
					customPriorityConfigWrapper3.ExitWrapper(false, reason);
				}
			}
			customPriorityConfigWrapper.EnterWrapper(false, false, reason);
			return true;
		}

		// Token: 0x0602F48D RID: 193677 RVA: 0x00B35820 File Offset: 0x00B33A20
		public bool TryExit(T enumValue, [Nullable(1)] string reason = "")
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 2);
			defaultInterpolatedStringHandler.AppendLiteral("[TryExit] [");
			defaultInterpolatedStringHandler.AppendFormatted(reason);
			defaultInterpolatedStringHandler.AppendLiteral("] [");
			defaultInterpolatedStringHandler.AppendFormatted<T>(enumValue);
			defaultInterpolatedStringHandler.AppendLiteral("]");
			this.LogInternal(defaultInterpolatedStringHandler.ToStringAndClear(), ELogLevel.Info);
			ICustomPriorityConfigWrapper<T> customPriorityConfigWrapper2;
			ICustomPriorityConfigWrapper<T> customPriorityConfigWrapper = this.Registry.TryGetValue(enumValue, out customPriorityConfigWrapper2) ? customPriorityConfigWrapper2 : null;
			if (customPriorityConfigWrapper == null)
			{
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 2);
				defaultInterpolatedStringHandler.AppendLiteral("[Exit] [");
				defaultInterpolatedStringHandler.AppendFormatted(reason);
				defaultInterpolatedStringHandler.AppendLiteral("] [");
				defaultInterpolatedStringHandler.AppendFormatted<T>(enumValue);
				defaultInterpolatedStringHandler.AppendLiteral("] not registered");
				this.LogInternal(defaultInterpolatedStringHandler.ToStringAndClear(), ELogLevel.Error);
				return false;
			}
			customPriorityConfigWrapper.Enable = false;
			if (!this.PriorityQueue.Has(enumValue))
			{
				if (customPriorityConfigWrapper.ForceExitCallback.GetValueOrDefault())
				{
					customPriorityConfigWrapper.ExitWrapper(false, reason + " [not in priority queue]");
				}
				return false;
			}
			T? t = this.PriorityQueue.Empty ? null : new T?(this.PriorityQueue.Top);
			this.PriorityQueue.Remove(enumValue);
			if (object.Equals(enumValue, t))
			{
				if (customPriorityConfigWrapper != null)
				{
					customPriorityConfigWrapper.ExitWrapper(false, reason);
				}
				T? t2 = this.PriorityQueue.Empty ? null : new T?(this.PriorityQueue.Top);
				if (t2 != null)
				{
					ICustomPriorityConfigWrapper<T> customPriorityConfigWrapper3;
					this.Registry.TryGetValue(t2.Value, out customPriorityConfigWrapper3);
					if (customPriorityConfigWrapper3 != null)
					{
						customPriorityConfigWrapper3.EnterWrapper(false, false, reason);
					}
				}
			}
			return true;
		}

		// Token: 0x0602F48E RID: 193678 RVA: 0x00B359D8 File Offset: 0x00B33BD8
		[NullableContext(1)]
		public void TryExitAll(string reason = "")
		{
			while (!this.PriorityQueue.Empty)
			{
				T top = this.PriorityQueue.Top;
				if (object.Equals(top, null))
				{
					break;
				}
				this.TryExit(top, "TryExitAll: " + reason);
			}
		}

		// Token: 0x0401AEDC RID: 110300
		[Nullable(1)]
		private const string DEBUG_KEY = "CustomPriorityManager";

		// Token: 0x0401AEDD RID: 110301
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			0
		})]
		private readonly Dictionary<T, ICustomPriorityConfigWrapper<T>> Registry = new Dictionary<T, ICustomPriorityConfigWrapper<T>>();

		// Token: 0x0401AEDE RID: 110302
		[Nullable(new byte[]
		{
			1,
			0
		})]
		private readonly PriorityQueue<T> PriorityQueue;

		// Token: 0x0401AEDF RID: 110303
		[Nullable(1)]
		private readonly string Identifier;
	}
}

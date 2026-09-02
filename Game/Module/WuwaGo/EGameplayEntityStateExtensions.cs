using System;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004ABB RID: 19131
	public static class EGameplayEntityStateExtensions
	{
		// Token: 0x06031E17 RID: 204311 RVA: 0x00C7B6B0 File Offset: 0x00C798B0
		public static string ToEnumString(this EGameplayEntityState value)
		{
			string result;
			switch (value)
			{
			case EGameplayEntityState.Locked:
				result = "关卡.Common.状态.封锁";
				break;
			case EGameplayEntityState.Normal:
				result = "关卡.Common.状态.常态";
				break;
			case EGameplayEntityState.Activated:
				result = "关卡.Common.状态.激活";
				break;
			case EGameplayEntityState.Completed:
				result = "关卡.Common.状态.完成";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x06031E18 RID: 204312 RVA: 0x00C7B704 File Offset: 0x00C79904
		public static EGameplayEntityState FromString(string name)
		{
			EGameplayEntityState result;
			if (!EGameplayEntityStateExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EGameplayEntityState 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06031E19 RID: 204313 RVA: 0x00C7B730 File Offset: 0x00C79930
		public static bool TryFromString(string name, out EGameplayEntityState value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EGameplayEntityState.Locked;
				return false;
			}
			if (name == "关卡.Common.状态.封锁")
			{
				value = EGameplayEntityState.Locked;
				return true;
			}
			if (name == "关卡.Common.状态.常态")
			{
				value = EGameplayEntityState.Normal;
				return true;
			}
			if (name == "关卡.Common.状态.激活")
			{
				value = EGameplayEntityState.Activated;
				return true;
			}
			if (!(name == "关卡.Common.状态.完成"))
			{
				value = EGameplayEntityState.Locked;
				return false;
			}
			value = EGameplayEntityState.Completed;
			return true;
		}

		// Token: 0x06031E1A RID: 204314 RVA: 0x00C7B798 File Offset: 0x00C79998
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"关卡.Common.状态.封锁",
				"关卡.Common.状态.常态",
				"关卡.Common.状态.激活",
				"关卡.Common.状态.完成"
			};
		}

		// Token: 0x06031E1B RID: 204315 RVA: 0x00C7B7C0 File Offset: 0x00C799C0
		public static EGameplayEntityState[] GetValues()
		{
			return new EGameplayEntityState[]
			{
				EGameplayEntityState.Locked,
				EGameplayEntityState.Normal,
				EGameplayEntityState.Activated,
				EGameplayEntityState.Completed
			};
		}

		// Token: 0x06031E1C RID: 204316 RVA: 0x00C7B7D3 File Offset: 0x00C799D3
		public static string[] GetNames()
		{
			return new string[]
			{
				"Locked",
				"Normal",
				"Activated",
				"Completed"
			};
		}
	}
}

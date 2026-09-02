using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.SkipInterface
{
	// Token: 0x02004F21 RID: 20257
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class SkipInterfaceModel : ModelBase<SkipInterfaceModel>
	{
		// Token: 0x06034585 RID: 214405 RVA: 0x00D196A8 File Offset: 0x00D178A8
		protected override bool OnInit()
		{
			this.ResetToBattleViewCount = ConfigCommonParamById.GetIntConfig("ResetToBattleViewCount").GetValueOrDefault();
			return true;
		}

		// Token: 0x06034586 RID: 214406 RVA: 0x00D196D0 File Offset: 0x00D178D0
		public bool CheckAccessPathCondition(int id)
		{
			bool flag = true;
			AccessPath? accessPathConfig = ConfigBase<SkipInterfaceConfig>.Instance.GetAccessPathConfig(id);
			if (accessPathConfig != null)
			{
				int[] array = accessPathConfig.Value.ClientCondition();
				if (array != null && array.Length > 1)
				{
					int conditionType = array[0];
					int[] array2 = new int[array.Length - 1];
					Array.Copy(array, 1, array2, 0, array2.Length);
					flag = this.SkipConditionContext.Check((ESkipConditionType)conditionType, array2);
				}
			}
			return flag && this.IsAccessPathInOpenTime(id);
		}

		// Token: 0x06034587 RID: 214407 RVA: 0x00D1974C File Offset: 0x00D1794C
		public void FullUpdateAccessPathTimeServerConfig(AccessPathConfig[] configs)
		{
			this.AccessPathTimeServerConfigMap.Clear();
			foreach (AccessPathConfig accessPathConfig in configs)
			{
				this.AccessPathTimeServerConfigMap[accessPathConfig.Id] = accessPathConfig;
			}
		}

		// Token: 0x06034588 RID: 214408 RVA: 0x00D1978C File Offset: 0x00D1798C
		public bool IsAccessPathInOpenTime(int id)
		{
			AccessPathConfig accessPathConfig;
			if (this.AccessPathTimeServerConfigMap.TryGetValue(id, out accessPathConfig))
			{
				long beginTime = accessPathConfig.BeginTime;
				long endTime = accessPathConfig.EndTime;
				double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
				return serverTimeStamp >= (double)beginTime && serverTimeStamp <= (double)endTime;
			}
			return true;
		}

		// Token: 0x0401E300 RID: 123648
		public int ResetToBattleViewCount;

		// Token: 0x0401E301 RID: 123649
		public int ContainerLimitCount = 3;

		// Token: 0x0401E302 RID: 123650
		private readonly SkipConditionContext SkipConditionContext = new SkipConditionContext();

		// Token: 0x0401E303 RID: 123651
		private readonly Dictionary<int, AccessPathConfig> AccessPathTimeServerConfigMap = new Dictionary<int, AccessPathConfig>();
	}
}

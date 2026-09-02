using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BC2 RID: 23490
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class InstanceDungeonGuideModel : ModelBase<InstanceDungeonGuideModel>
	{
		// Token: 0x0603B779 RID: 243577 RVA: 0x00F132A6 File Offset: 0x00F114A6
		public int GetCurrentInstanceDungeonGuideType()
		{
			return this.CurrentInstanceDungeonGuideType;
		}

		// Token: 0x0603B77A RID: 243578 RVA: 0x00F132AE File Offset: 0x00F114AE
		public int GetCurrentInstanceDungeonGuideValue()
		{
			return this.CurrentInstanceDungeonGuideValue;
		}

		// Token: 0x0603B77B RID: 243579 RVA: 0x00F132B8 File Offset: 0x00F114B8
		public void RefreshCurrentDungeonGuide()
		{
			ValueTuple<int, int> guide = ConfigBase<InstanceDungeonConfig>.Instance.GetGuide(ModelBase<CreatureModel>.Instance.GetInstanceId());
			this.CurrentInstanceDungeonGuideType = guide.Item1;
			this.CurrentInstanceDungeonGuideValue = guide.Item2;
			Singleton<EventSystem>.Instance.Emit(EEventName.DungeonGuideChange);
		}

		// Token: 0x0603B77C RID: 243580 RVA: 0x00F13302 File Offset: 0x00F11502
		public bool GetHaveGuide()
		{
			return this.CurrentInstanceDungeonGuideType != 0;
		}

		// Token: 0x04021805 RID: 137221
		private int CurrentInstanceDungeonGuideType;

		// Token: 0x04021806 RID: 137222
		private int CurrentInstanceDungeonGuideValue;
	}
}

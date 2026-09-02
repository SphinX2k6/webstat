using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067A8 RID: 26536
	public class FishingPointData
	{
		// Token: 0x060422D5 RID: 271061 RVA: 0x010F9BDC File Offset: 0x010F7DDC
		[NullableContext(1)]
		public void Refresh(OneFishPointInfo data)
		{
			this.Id = data.Id;
			this.PbEntityId = data.EntityConfigId;
			this.GamePlayId = data.GamePlayId;
			this.CurrentCount = data.CurCount;
			if (this.CurrentCount == 0)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.FishingPointFinish, this.Id);
			}
			this.MaxCount = data.MaxCount;
			this.LastUpdateTime = data.LastUpdateTime;
			this.NextUpdateTime = data.NextUpdateTime;
			this.Interacted = data.Interacted;
		}

		// Token: 0x060422D6 RID: 271062 RVA: 0x010F9C67 File Offset: 0x010F7E67
		public bool IsValid()
		{
			return (double)this.NextUpdateTime >= Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		}

		// Token: 0x04024DCD RID: 150989
		public int Id;

		// Token: 0x04024DCE RID: 150990
		public int PbEntityId;

		// Token: 0x04024DCF RID: 150991
		public int SceneId;

		// Token: 0x04024DD0 RID: 150992
		public int GamePlayId;

		// Token: 0x04024DD1 RID: 150993
		public int CurrentCount;

		// Token: 0x04024DD2 RID: 150994
		public int MaxCount;

		// Token: 0x04024DD3 RID: 150995
		public long LastUpdateTime;

		// Token: 0x04024DD4 RID: 150996
		public long NextUpdateTime;

		// Token: 0x04024DD5 RID: 150997
		public bool Interacted;
	}
}

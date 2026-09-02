using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067A9 RID: 26537
	public class TempFishingPointData
	{
		// Token: 0x060422D8 RID: 271064 RVA: 0x010F9C87 File Offset: 0x010F7E87
		[NullableContext(1)]
		public void Refresh(TempFishPointInfo data)
		{
			this.Id = data.ConfigId;
			this.CreatureDataId = data.EntityId;
			this.GamePlayId = data.GamePlayId;
			this.CurrentCount = data.CurCount;
			this.MaxCount = data.MaxCount;
		}

		// Token: 0x04024DD6 RID: 150998
		public int Id;

		// Token: 0x04024DD7 RID: 150999
		public long CreatureDataId;

		// Token: 0x04024DD8 RID: 151000
		public int GamePlayId;

		// Token: 0x04024DD9 RID: 151001
		public int SceneId;

		// Token: 0x04024DDA RID: 151002
		public int CurrentCount;

		// Token: 0x04024DDB RID: 151003
		public int MaxCount;
	}
}

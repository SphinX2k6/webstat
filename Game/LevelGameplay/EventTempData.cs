using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A5B RID: 27227
	[NullableContext(1)]
	[Nullable(0)]
	public class EventTempData : IStaticVariableResetter
	{
		// Token: 0x06043557 RID: 275799 RVA: 0x0114FB8A File Offset: 0x0114DD8A
		static EventTempData()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(EventTempData.CreateStaticDefaultValue), new Action(EventTempData.ResetStaticDefaultValue));
		}

		// Token: 0x06043558 RID: 275800 RVA: 0x0114FBAC File Offset: 0x0114DDAC
		public void Reset()
		{
			this.EventType = "";
			this.EventParams = null;
			this.EventParamsNew = null;
			this.EventType = "";
			this.Context = null;
			this.PlayerId = -1;
			this.SessionId = -1;
			this.ActionIndex = -1;
			this.ActionId = 0;
			this.EventEntityId = 0;
			this.EventTrigger = null;
			this.IsAsync = false;
		}

		// Token: 0x06043559 RID: 275801 RVA: 0x0114FC18 File Offset: 0x0114DE18
		public static EventTempData Create()
		{
			if (EventTempData.Pool.Count > 0)
			{
				EventTempData result = EventTempData.Pool[EventTempData.Pool.Count - 1];
				EventTempData.Pool.RemoveAt(EventTempData.Pool.Count - 1);
				return result;
			}
			return new EventTempData();
		}

		// Token: 0x0604355A RID: 275802 RVA: 0x0114FC64 File Offset: 0x0114DE64
		public static void Release(EventTempData data)
		{
			data.Reset();
			EventTempData.Pool.Add(data);
		}

		// Token: 0x0604355B RID: 275803 RVA: 0x0114FC77 File Offset: 0x0114DE77
		public static void CreateStaticDefaultValue()
		{
			EventTempData.Pool = new List<EventTempData>();
		}

		// Token: 0x0604355C RID: 275804 RVA: 0x0114FC83 File Offset: 0x0114DE83
		public static void ResetStaticDefaultValue()
		{
			EventTempData.Pool = null;
		}

		// Token: 0x040258BA RID: 153786
		public string EventType = "";

		// Token: 0x040258BB RID: 153787
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<string, string> EventParams;

		// Token: 0x040258BC RID: 153788
		[Nullable(2)]
		public ActionParams EventParamsNew;

		// Token: 0x040258BD RID: 153789
		public int EventEntityId;

		// Token: 0x040258BE RID: 153790
		[Nullable(2)]
		public GeneralContext Context;

		// Token: 0x040258BF RID: 153791
		public int PlayerId = -1;

		// Token: 0x040258C0 RID: 153792
		public int SessionId = -1;

		// Token: 0x040258C1 RID: 153793
		public int ActionIndex = -1;

		// Token: 0x040258C2 RID: 153794
		public int ActionId;

		// Token: 0x040258C3 RID: 153795
		public string ActionGuid = "";

		// Token: 0x040258C4 RID: 153796
		public bool IsAsync;

		// Token: 0x040258C5 RID: 153797
		[Nullable(2)]
		public AActor EventTrigger;

		// Token: 0x040258C6 RID: 153798
		private static List<EventTempData> Pool;
	}
}

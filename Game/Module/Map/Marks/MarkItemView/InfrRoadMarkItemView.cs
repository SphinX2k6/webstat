using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.Marks.MarkItem;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005874 RID: 22644
	public class InfrRoadMarkItemView : ConfigMarkItemView
	{
		// Token: 0x0603991A RID: 235802 RVA: 0x00E9B10B File Offset: 0x00E9930B
		[NullableContext(1)]
		public InfrRoadMarkItemView(InfrRoadMarkItem markItem) : base(markItem)
		{
		}

		// Token: 0x0603991B RID: 235803 RVA: 0x00E9B114 File Offset: 0x00E99314
		public override void RegisterEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.InfrastructureRoadDataUpdate, new Action(this.OnRoadDataChange));
		}

		// Token: 0x0603991C RID: 235804 RVA: 0x00E9B132 File Offset: 0x00E99332
		public override void UnRegisterEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.InfrastructureRoadDataUpdate, new Action(this.OnRoadDataChange));
		}

		// Token: 0x0603991D RID: 235805 RVA: 0x00E9B150 File Offset: 0x00E99350
		private void OnRoadDataChange()
		{
			(this.Holder as InfrRoadMarkItem).UpdateGamePlayState();
			base.MarkItemTopRightIconHandle.Update();
			base.MarkItemTopRightIconHandle.ApplyModified();
		}
	}
}

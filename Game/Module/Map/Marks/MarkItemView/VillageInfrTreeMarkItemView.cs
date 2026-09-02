using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.Marks.MarkItem;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x0200588A RID: 22666
	public class VillageInfrTreeMarkItemView : ConfigMarkItemView
	{
		// Token: 0x060399E2 RID: 236002 RVA: 0x00E9D947 File Offset: 0x00E9BB47
		[NullableContext(1)]
		public VillageInfrTreeMarkItemView(VillageInfrTreeMarkItem markItem) : base(markItem)
		{
		}

		// Token: 0x060399E3 RID: 236003 RVA: 0x00E9D950 File Offset: 0x00E9BB50
		public override void RegisterEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.VillageInfrTreeDataUpdate, new Action(this.OnTreeDataChange));
		}

		// Token: 0x060399E4 RID: 236004 RVA: 0x00E9D96E File Offset: 0x00E9BB6E
		public override void UnRegisterEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.VillageInfrTreeDataUpdate, new Action(this.OnTreeDataChange));
		}

		// Token: 0x060399E5 RID: 236005 RVA: 0x00E9D98C File Offset: 0x00E9BB8C
		private void OnTreeDataChange()
		{
			(this.Holder as VillageInfrTreeMarkItem).UpdateGamePlayState();
			base.MarkItemTopRightIconHandle.Update();
			base.MarkItemTopRightIconHandle.ApplyModified();
		}
	}
}

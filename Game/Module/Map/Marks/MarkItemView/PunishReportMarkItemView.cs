using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.Marks.MarkItem;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x0200587E RID: 22654
	[NullableContext(1)]
	[Nullable(0)]
	public class PunishReportMarkItemView : ConfigMarkItemView
	{
		// Token: 0x0603999D RID: 235933 RVA: 0x00E9CAD7 File Offset: 0x00E9ACD7
		public PunishReportMarkItemView(PunishReportMarkItem holder) : base(holder)
		{
			this.PunishReportMarkItem = holder;
		}

		// Token: 0x0603999E RID: 235934 RVA: 0x00E9CAE7 File Offset: 0x00E9ACE7
		protected override void OnViewRefresh()
		{
			this.PunishReportMarkItem.UpdateIconPath();
			this.OnIconPathChanged(this.Holder.IconPath);
		}

		// Token: 0x0603999F RID: 235935 RVA: 0x00E9CB05 File Offset: 0x00E9AD05
		public override void RegisterEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnPunishMarkStateChanged, new Action(this.OnPunishMarkStateChanged));
		}

		// Token: 0x060399A0 RID: 235936 RVA: 0x00E9CB23 File Offset: 0x00E9AD23
		public override void UnRegisterEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPunishMarkStateChanged, new Action(this.OnPunishMarkStateChanged));
		}

		// Token: 0x060399A1 RID: 235937 RVA: 0x00E9CB41 File Offset: 0x00E9AD41
		protected override void OnSafeUpdate(Vector playerLocation, bool bDragging = false, bool bIsScale = false)
		{
			this.PunishReportMarkItem.UpdateIconPath();
			this.OnIconPathChanged(this.Holder.IconPath);
		}

		// Token: 0x060399A2 RID: 235938 RVA: 0x00E9CB5F File Offset: 0x00E9AD5F
		private void OnPunishMarkStateChanged()
		{
			this.PunishReportMarkItem.UpdateIconPath();
			this.OnIconPathChanged(this.Holder.IconPath);
		}

		// Token: 0x04020AD5 RID: 133845
		[Nullable(2)]
		private readonly PunishReportMarkItem PunishReportMarkItem;
	}
}

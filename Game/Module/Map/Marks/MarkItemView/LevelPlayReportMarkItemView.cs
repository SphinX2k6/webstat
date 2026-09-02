using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.Marks.MarkItem;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005876 RID: 22646
	public class LevelPlayReportMarkItemView : ConfigMarkItemView
	{
		// Token: 0x06039925 RID: 235813 RVA: 0x00E9B209 File Offset: 0x00E99409
		[NullableContext(1)]
		public LevelPlayReportMarkItemView(LevelPlayReportMarkItem holder) : base(holder)
		{
		}

		// Token: 0x06039926 RID: 235814 RVA: 0x00E9B214 File Offset: 0x00E99414
		public override void RegisterEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.LevelPlayStateDetailUpdate, new Action(this.OnLevelPlayStateDetailUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.LevelPlayMarkGamePlayStateUpdate, new Action<int>(this.OnLevelPlayStateChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.CommonPlayMarkGamePlayStateUpdate, new Action<int>(this.OnLevelPlayStateChanged));
		}

		// Token: 0x06039927 RID: 235815 RVA: 0x00E9B278 File Offset: 0x00E99478
		public override void UnRegisterEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.LevelPlayStateDetailUpdate, new Action(this.OnLevelPlayStateDetailUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.LevelPlayMarkGamePlayStateUpdate, new Action<int>(this.OnLevelPlayStateChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.CommonPlayMarkGamePlayStateUpdate, new Action<int>(this.OnLevelPlayStateChanged));
		}

		// Token: 0x06039928 RID: 235816 RVA: 0x00E9B2D9 File Offset: 0x00E994D9
		private void OnLevelPlayStateDetailUpdate()
		{
			base.MarkItemTopRightIconHandle.Update();
		}

		// Token: 0x06039929 RID: 235817 RVA: 0x00E9B2E6 File Offset: 0x00E994E6
		private void OnLevelPlayStateChanged(int markId)
		{
			if (markId != this.Holder.MarkId)
			{
				return;
			}
			base.MarkItemTopRightIconHandle.Update();
			base.MarkItemTopRightIconHandle.ApplyModified();
		}

		// Token: 0x0603992A RID: 235818 RVA: 0x00E9B30D File Offset: 0x00E9950D
		protected override void OnViewRefresh()
		{
			this.UpdateIcon();
		}

		// Token: 0x0603992B RID: 235819 RVA: 0x00E9B315 File Offset: 0x00E99515
		public override void UpdateIcon()
		{
			this.OnIconPathChanged(this.Holder.IconPath);
			base.MarkItemTopRightIconHandle.Update();
		}
	}
}

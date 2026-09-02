using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Marks.SubPanel;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005872 RID: 22642
	[NullableContext(1)]
	[Nullable(0)]
	public class HonamiScanMarkItemView : ConfigMarkItemView
	{
		// Token: 0x06039912 RID: 235794 RVA: 0x00E9AF50 File Offset: 0x00E99150
		public HonamiScanMarkItemView(HonamiScanMarkItem markItem) : base(markItem)
		{
		}

		// Token: 0x06039913 RID: 235795 RVA: 0x00E9AF64 File Offset: 0x00E99164
		public override void RegisterEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnHonamiScanMarkInfoUpdate, new Action<int>(this.OnHonamiScanMarkItemView));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapViewOpened, new Action(this.LoadEffect));
		}

		// Token: 0x06039914 RID: 235796 RVA: 0x00E9AF9E File Offset: 0x00E9919E
		public override void UnRegisterEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiScanMarkInfoUpdate, new Action<int>(this.OnHonamiScanMarkItemView));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapViewOpened, new Action(this.LoadEffect));
		}

		// Token: 0x06039915 RID: 235797 RVA: 0x00E9AFD8 File Offset: 0x00E991D8
		protected override UniTask OnBeforeStartAsync()
		{
			HonamiScanMarkItemView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiScanMarkItemView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039916 RID: 235798 RVA: 0x00E9B01C File Offset: 0x00E9921C
		private void OnHonamiScanMarkItemView(int markId)
		{
			if (base.MarkConfig.Value.MarkId == markId)
			{
				HonamiScanMarkItem honamiScanMarkItem = (HonamiScanMarkItem)this.Holder;
				honamiScanMarkItem.UpdateIcon();
				this.OnIconPathChanged(honamiScanMarkItem.IconPath);
			}
		}

		// Token: 0x06039917 RID: 235799 RVA: 0x00E9B060 File Offset: 0x00E99260
		protected override void OnBeforeDestroy()
		{
			this.EffectPanel.SetUiActive(false);
		}

		// Token: 0x06039918 RID: 235800 RVA: 0x00E9B070 File Offset: 0x00E99270
		private void LoadEffect()
		{
			MarkItem holder = this.Holder;
			if (holder == null || holder.MapType != EMapType.WorldMap)
			{
				return;
			}
			int? scanMarkId = ModelBase<HonamiStoryModel>.Instance.ScanMarkId;
			int markId = this.Holder.MarkId;
			if (!(scanMarkId.GetValueOrDefault() == markId & scanMarkId != null))
			{
				this.EffectPanel.SetUiActive(false);
				return;
			}
			this.EffectPanel.SetUiActive(true);
			ModelBase<HonamiStoryModel>.Instance.ScanMarkId = null;
			this.EffectPanel.SetNiagaraAndShow("NS_Fx_LGUI_HonamiStory_Map_Kuosan", "play_ui_honamistory_scan_mark_start");
		}

		// Token: 0x04020ABA RID: 133818
		private readonly HonamiNiagaraPanel EffectPanel = new HonamiNiagaraPanel();
	}
}

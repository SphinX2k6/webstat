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
	// Token: 0x02005871 RID: 22641
	[NullableContext(1)]
	[Nullable(0)]
	public class HonamiScanItemMarkItemView : ServerMarkItemView
	{
		// Token: 0x0603990B RID: 235787 RVA: 0x00E9AD7E File Offset: 0x00E98F7E
		public HonamiScanItemMarkItemView(HonamiScanItemMarkItem markItem) : base(markItem)
		{
		}

		// Token: 0x0603990C RID: 235788 RVA: 0x00E9AD94 File Offset: 0x00E98F94
		public override void RegisterEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldMapViewOpened, new Action(this.LoadEffect));
			MarkItem holder = this.Holder;
			if (holder != null && holder.MapType == EMapType.WorldMap)
			{
				Singleton<EventSystem>.Instance.Add<int>(EEventName.WorldMapSubMapChangedFromUpdate, new Action<int>(this.OnSubMapChanged));
			}
		}

		// Token: 0x0603990D RID: 235789 RVA: 0x00E9ADF0 File Offset: 0x00E98FF0
		public override void UnRegisterEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldMapViewOpened, new Action(this.LoadEffect));
			MarkItem holder = this.Holder;
			if (holder != null && holder.MapType == EMapType.WorldMap)
			{
				Singleton<EventSystem>.Instance.Remove<int>(EEventName.WorldMapSubMapChangedFromUpdate, new Action<int>(this.OnSubMapChanged));
			}
		}

		// Token: 0x0603990E RID: 235790 RVA: 0x00E9AE4C File Offset: 0x00E9904C
		protected override UniTask OnBeforeStartAsync()
		{
			HonamiScanItemMarkItemView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiScanItemMarkItemView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603990F RID: 235791 RVA: 0x00E9AE90 File Offset: 0x00E99090
		private void LoadEffect()
		{
			MarkItem holder = this.Holder;
			if (holder == null || holder.MapType != EMapType.WorldMap)
			{
				return;
			}
			if (!ModelBase<HonamiStoryModel>.Instance.ScanMarkItemIds.Contains(this.Holder.MarkId))
			{
				this.EffectPanel.SetUiActive(false);
				return;
			}
			this.EffectPanel.SetUiActive(true);
			ModelBase<HonamiStoryModel>.Instance.ScanMarkItemIds.Remove(this.Holder.MarkId);
			this.EffectPanel.SetNiagaraAndShow("NS_Fx_LGUI_HonamiStory_Map_Burst", null);
		}

		// Token: 0x06039910 RID: 235792 RVA: 0x00E9AF1A File Offset: 0x00E9911A
		public override void OnIconPathChanged(string iconPath)
		{
			base.OnIconPathChanged(iconPath);
			base.MarkItemChildIconHandle.Update();
			base.MarkItemChildIconHandle.ApplyModified();
		}

		// Token: 0x06039911 RID: 235793 RVA: 0x00E9AF39 File Offset: 0x00E99139
		protected void OnSubMapChanged(int floorIndex)
		{
			HonamiScanItemMarkItem honamiScanItemMarkItem = this.Holder as HonamiScanItemMarkItem;
			if (honamiScanItemMarkItem == null)
			{
				return;
			}
			honamiScanItemMarkItem.RefreshSubMapState();
		}

		// Token: 0x04020AB9 RID: 133817
		private readonly HonamiNiagaraPanel EffectPanel = new HonamiNiagaraPanel();
	}
}

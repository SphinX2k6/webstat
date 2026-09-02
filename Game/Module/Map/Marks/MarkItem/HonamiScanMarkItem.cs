using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005849 RID: 22601
	[NullableContext(1)]
	[Nullable(0)]
	public class HonamiScanMarkItem : ConfigMarkItem
	{
		// Token: 0x06039751 RID: 235345 RVA: 0x00E95A8D File Offset: 0x00E93C8D
		public HonamiScanMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.Instance) : base(markId, markConfig, parent, mapType, markScale, new ETrackSource?(trackSource))
		{
		}

		// Token: 0x06039752 RID: 235346 RVA: 0x00E95AAE File Offset: 0x00E93CAE
		protected override void OnInitialize()
		{
			base.OnInitialize();
			this.UpdateGamePlayState();
			this.RefreshSubMapState();
		}

		// Token: 0x06039753 RID: 235347 RVA: 0x00E95AC2 File Offset: 0x00E93CC2
		protected override void OnUpdate(global::Vector playerLocation)
		{
			base.OnUpdate(playerLocation);
			if (base.MapType == EMapType.MiniMap)
			{
				this.RefreshSubMapState();
			}
		}

		// Token: 0x06039754 RID: 235348 RVA: 0x00E95ADA File Offset: 0x00E93CDA
		protected override void InitIcon()
		{
			this.UpdateIcon();
		}

		// Token: 0x06039755 RID: 235349 RVA: 0x00E95AE4 File Offset: 0x00E93CE4
		public void UpdateIcon()
		{
			this.IconPathInner = (this.IsLocked ? this.MarkConfig.Value.LockMarkPic : this.MarkConfig.Value.UnlockMarkPic);
		}

		// Token: 0x06039756 RID: 235350 RVA: 0x00E95B27 File Offset: 0x00E93D27
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.HonamiScanMarkItemView;
		}

		// Token: 0x06039757 RID: 235351 RVA: 0x00E95B2B File Offset: 0x00E93D2B
		[PreserveBaseOverrides]
		protected new virtual HonamiScanMarkItemView CreateView()
		{
			return new HonamiScanMarkItemView(this);
		}

		// Token: 0x17009298 RID: 37528
		// (get) Token: 0x06039758 RID: 235352 RVA: 0x00E95B33 File Offset: 0x00E93D33
		public override bool IsLocked
		{
			get
			{
				return ModelBase<MapModel>.Instance.GetHonamiScanMarkInfo(this.MarkId) == MarkState.MarkDisable;
			}
		}

		// Token: 0x17009299 RID: 37529
		// (get) Token: 0x06039759 RID: 235353 RVA: 0x00E95B48 File Offset: 0x00E93D48
		// (set) Token: 0x0603975A RID: 235354 RVA: 0x00E95B50 File Offset: 0x00E93D50
		public override string IconPath
		{
			get
			{
				return this.IconPathInner;
			}
			set
			{
				this.IconPathInner = value;
			}
		}

		// Token: 0x0603975B RID: 235355 RVA: 0x00E95B59 File Offset: 0x00E93D59
		protected override bool GamePlayIsFinish()
		{
			return ModelBase<MapModel>.Instance.GetHonamiScanMarkInfo(this.MarkId) == MarkState.MarkComplete;
		}

		// Token: 0x0603975C RID: 235356 RVA: 0x00E95B6E File Offset: 0x00E93D6E
		private void UpdateGamePlayState()
		{
			base.MarkItemEntity.GamePlay.GamePlayState = (this.GamePlayIsFinish() ? EMarkGamePlayState.Finish : EMarkGamePlayState.Lock);
		}

		// Token: 0x0603975D RID: 235357 RVA: 0x00E95B8C File Offset: 0x00E93D8C
		private void RefreshSubMapState()
		{
			base.IsSelectThisFloor = this.GetIsSelectThisFloor();
		}

		// Token: 0x04020A51 RID: 133713
		[Nullable(2)]
		public HonamiScanMarkItemView InnerView;

		// Token: 0x04020A52 RID: 133714
		public bool IsDirty;

		// Token: 0x04020A53 RID: 133715
		private string IconPathInner = "";
	}
}

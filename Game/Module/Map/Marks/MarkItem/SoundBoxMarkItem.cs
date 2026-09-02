using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005858 RID: 22616
	[NullableContext(1)]
	[Nullable(0)]
	public class SoundBoxMarkItem : ServerMarkItem
	{
		// Token: 0x170092D3 RID: 37587
		// (get) Token: 0x06039853 RID: 235603 RVA: 0x00E98648 File Offset: 0x00E96848
		public override EMarkType MarkType
		{
			get
			{
				DynamicMarkCreateInfo serverMarkInfo = this.ServerMarkInfo;
				if (serverMarkInfo == null)
				{
					return EMarkType.SoundBox;
				}
				return serverMarkInfo.MarkType;
			}
		}

		// Token: 0x170092D4 RID: 37588
		// (get) Token: 0x06039854 RID: 235604 RVA: 0x00E9865C File Offset: 0x00E9685C
		public bool IsNewCustomMarkItem
		{
			get
			{
				return this.IsNew;
			}
		}

		// Token: 0x06039855 RID: 235605 RVA: 0x00E98664 File Offset: 0x00E96864
		public SoundBoxMarkItem(DynamicMarkCreateInfo markPointInfo, UUIItem parent, EMapType mapType, float markScale) : base(markPointInfo, parent, mapType, markScale)
		{
		}

		// Token: 0x06039856 RID: 235606 RVA: 0x00E98674 File Offset: 0x00E96874
		protected override void OnInitialize()
		{
			base.OnInitialize();
			DynamicMarkCreateInfo serverMarkInfo = this.ServerMarkInfo;
			base.SetTrackData(serverMarkInfo.TrackTarget);
			this.SetConfigId(base.ConfigId);
			this.UpdateVisibleRelativeState();
		}

		// Token: 0x06039857 RID: 235607 RVA: 0x00E986AC File Offset: 0x00E968AC
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.SoundBoxMarkItemView;
		}

		// Token: 0x06039858 RID: 235608 RVA: 0x00E986B0 File Offset: 0x00E968B0
		[PreserveBaseOverrides]
		protected new virtual SoundBoxMarkItemView CreateView()
		{
			return new SoundBoxMarkItemView(this);
		}

		// Token: 0x06039859 RID: 235609 RVA: 0x00E986B8 File Offset: 0x00E968B8
		public void SetConfigId(int configId)
		{
			this.ServerMarkInfo.MarkConfigId = configId;
			this.OnSetConfigId(configId);
		}

		// Token: 0x0603985A RID: 235610 RVA: 0x00E986D0 File Offset: 0x00E968D0
		public void OnSetConfigId(int configId)
		{
			SoundBoxMark? soundBoxMarkConfig = ConfigBase<MapConfig>.Instance.GetSoundBoxMarkConfig(configId);
			this.OnAfterSetConfigId(new MarkItemData
			{
				MarkPic = ((soundBoxMarkConfig != null) ? soundBoxMarkConfig.GetValueOrDefault().MarkPic : null),
				Scale = ((soundBoxMarkConfig != null) ? new float?(soundBoxMarkConfig.GetValueOrDefault().Scale) : null),
				ShowPriority = ((soundBoxMarkConfig != null) ? new int?(soundBoxMarkConfig.GetValueOrDefault().ShowPriority) : null),
				ShowRange = ((soundBoxMarkConfig != null) ? soundBoxMarkConfig.GetValueOrDefault().ShowRange() : null)
			});
		}

		// Token: 0x0603985B RID: 235611 RVA: 0x00E98792 File Offset: 0x00E96992
		public void SetIsNew(bool isNew)
		{
			this.IsNew = isNew;
		}

		// Token: 0x0603985C RID: 235612 RVA: 0x00E9879C File Offset: 0x00E9699C
		[NullableContext(2)]
		public override string GetTitleText()
		{
			return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<MapConfig>.Instance.GetSoundBoxMarkConfig(base.ConfigId).Value.MarkTitle, null);
		}

		// Token: 0x0603985D RID: 235613 RVA: 0x00E987D0 File Offset: 0x00E969D0
		[NullableContext(2)]
		public string GetDescText()
		{
			return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<MapConfig>.Instance.GetSoundBoxMarkConfig(base.ConfigId).Value.MarkDesc, null);
		}

		// Token: 0x0603985E RID: 235614 RVA: 0x00E98804 File Offset: 0x00E96A04
		public int? GetSoundBoxEntityId()
		{
			DynamicMarkCreateInfo serverMarkInfo = this.ServerMarkInfo;
			if (serverMarkInfo == null)
			{
				return null;
			}
			return serverMarkInfo.EntityConfigId;
		}

		// Token: 0x0603985F RID: 235615 RVA: 0x00E9882A File Offset: 0x00E96A2A
		public override bool GetInteractiveFlag()
		{
			return false;
		}

		// Token: 0x04020A85 RID: 133765
		public int DetectorId;

		// Token: 0x04020A86 RID: 133766
		private bool IsNew;
	}
}

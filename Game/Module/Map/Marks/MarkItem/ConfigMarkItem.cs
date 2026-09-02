using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using CSharpScript.Game.Module.WorldMap;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005839 RID: 22585
	[NullableContext(1)]
	[Nullable(0)]
	public class ConfigMarkItem : MarkItem
	{
		// Token: 0x17009273 RID: 37491
		// (get) Token: 0x06039692 RID: 235154 RVA: 0x00E937BE File Offset: 0x00E919BE
		public virtual bool IsFogUnlock
		{
			get
			{
				return ModelBase<MapModel>.Instance.IsMarkFogUnlock(this.MarkConfigId);
			}
		}

		// Token: 0x17009274 RID: 37492
		// (get) Token: 0x06039693 RID: 235155 RVA: 0x00E937D0 File Offset: 0x00E919D0
		public virtual bool IsLocked
		{
			get
			{
				return base.MarkItemEntity.GamePlay.IsTeleportLocked;
			}
		}

		// Token: 0x17009275 RID: 37493
		// (get) Token: 0x06039694 RID: 235156 RVA: 0x00E937E2 File Offset: 0x00E919E2
		public override EMarkItemType MarkItemType
		{
			get
			{
				return EMarkItemType.Config;
			}
		}

		// Token: 0x06039695 RID: 235157 RVA: 0x00E937E8 File Offset: 0x00E919E8
		public override bool IsMultiMap()
		{
			return this.MarkConfig.Value.MultiMapFloorId != 0 || this.GetConnectMultiMapIds().Length > 0;
		}

		// Token: 0x06039696 RID: 235158 RVA: 0x00E93820 File Offset: 0x00E91A20
		public override bool LocateInGround()
		{
			return this.MarkConfig.Value.MultiMapFloorId == 0 && this.GetConnectMultiMapIds().Length > 0;
		}

		// Token: 0x06039697 RID: 235159 RVA: 0x00E93858 File Offset: 0x00E91A58
		public unsafe override bool ConnectGround()
		{
			if (this.IsMultiMap())
			{
				int multiMapFloorId = this.MarkConfig.Value.MultiMapFloorId;
				if (multiMapFloorId != 0)
				{
					MultiMap? subMapConfigById = ConfigBase<MapConfig>.Instance.GetSubMapConfigById(multiMapFloorId);
					if (subMapConfigById != null && subMapConfigById.GetValueOrDefault().Floor == 0)
					{
						return true;
					}
				}
				Span<int> connectMultiMapIds = this.GetConnectMultiMapIds();
				for (int i = 0; i < connectMultiMapIds.Length; i++)
				{
					int id = *connectMultiMapIds[i];
					MultiMap? subMapConfigById2 = ConfigBase<MapConfig>.Instance.GetSubMapConfigById(id);
					if (subMapConfigById2 != null && subMapConfigById2.GetValueOrDefault().Floor == 0)
					{
						return true;
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x06039698 RID: 235160 RVA: 0x00E93914 File Offset: 0x00E91B14
		public unsafe override int GetMultiMapId()
		{
			int multiMapFloorId = this.MarkConfig.Value.MultiMapFloorId;
			if (multiMapFloorId != 0)
			{
				return multiMapFloorId;
			}
			Span<int> connectMultiMapIds = this.GetConnectMultiMapIds();
			if (connectMultiMapIds.Length <= 0)
			{
				return 0;
			}
			return *connectMultiMapIds[0];
		}

		// Token: 0x06039699 RID: 235161 RVA: 0x00E93958 File Offset: 0x00E91B58
		[NullableContext(0)]
		public Span<int> GetConnectMultiMapIds()
		{
			return this.MarkConfig.Value.GetConnetMultiMapFloorIdBytes();
		}

		// Token: 0x17009276 RID: 37494
		// (get) Token: 0x0603969A RID: 235162 RVA: 0x00E93978 File Offset: 0x00E91B78
		// (set) Token: 0x0603969B RID: 235163 RVA: 0x00E93980 File Offset: 0x00E91B80
		public override int MarkId
		{
			get
			{
				return this.InnerMarkId;
			}
			set
			{
				this.InnerMarkId = value;
			}
		}

		// Token: 0x17009277 RID: 37495
		// (get) Token: 0x0603969C RID: 235164 RVA: 0x00E9398C File Offset: 0x00E91B8C
		public int MarkConfigId
		{
			get
			{
				return this.MarkConfig.Value.MarkId;
			}
		}

		// Token: 0x17009278 RID: 37496
		// (get) Token: 0x0603969D RID: 235165 RVA: 0x00E939AC File Offset: 0x00E91BAC
		public override EMarkType MarkType
		{
			get
			{
				return (EMarkType)this.MarkConfig.Value.ObjectType;
			}
		}

		// Token: 0x17009279 RID: 37497
		// (get) Token: 0x0603969E RID: 235166 RVA: 0x00E939CC File Offset: 0x00E91BCC
		public override int MapId
		{
			get
			{
				return this.MarkConfig.Value.MapId;
			}
		}

		// Token: 0x1700927A RID: 37498
		// (get) Token: 0x0603969F RID: 235167 RVA: 0x00E939EC File Offset: 0x00E91BEC
		public override int? InstanceDungeonId
		{
			get
			{
				return new int?(this.MarkConfig.Value.InstanceDungeonId);
			}
		}

		// Token: 0x1700927B RID: 37499
		// (get) Token: 0x060396A0 RID: 235168 RVA: 0x00E93A14 File Offset: 0x00E91C14
		public override int? RelativeInstanceDungeonId
		{
			get
			{
				return new int?(this.MarkConfig.Value.RelativeDungeonId);
			}
		}

		// Token: 0x060396A1 RID: 235169 RVA: 0x00E93A3C File Offset: 0x00E91C3C
		public ConfigMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource? trackSource = null) : base(parent, mapType, markScale, trackSource ?? ((markConfig.InstanceDungeonId != 0) ? ETrackSource.Instance : ETrackSource.MapMark))
		{
			this.InnerMarkId = markId;
			base.ShowPriority = markConfig.ShowPriority;
			this.MarkConfig = new MapMark?(markConfig);
			this.IconPath = this.MarkConfig.Value.LockMarkPic;
		}

		// Token: 0x060396A2 RID: 235170 RVA: 0x00E93AB8 File Offset: 0x00E91CB8
		protected override void OnInitialize()
		{
			if (this.MarkConfig.Value.Scale != 0f)
			{
				base.SetConfigScale(this.MarkConfig.Value.Scale);
			}
			if (this.MarkConfig.Value.CornerScale != 0f)
			{
				base.SetCornerScale(this.MarkConfig.Value.CornerScale);
			}
			this.InitShowCondition();
			this.InitPosition();
			this.InitIcon();
		}

		// Token: 0x060396A3 RID: 235171 RVA: 0x00E93B3D File Offset: 0x00E91D3D
		protected virtual void InitPosition()
		{
			base.SetTrackData(ModelBase<MapModel>.Instance.GetConfigMarkTrackTarget(this.MarkId));
			this.UpdateVisibleRelativeState();
		}

		// Token: 0x060396A4 RID: 235172 RVA: 0x00E93B5B File Offset: 0x00E91D5B
		protected virtual void InitIcon()
		{
			this.UpdateIconPath();
		}

		// Token: 0x060396A5 RID: 235173 RVA: 0x00E93B64 File Offset: 0x00E91D64
		public virtual void UpdateIconPath()
		{
			if (this.MarkConfig.Value.RelativeSubType <= 0)
			{
				return;
			}
			if (this.MarkConfig.Value.RelativeSubType == 7)
			{
				this.IconPath = (ModelBase<MapModel>.Instance.IsInstanceTeleportUnlock(this.MarkId) ? this.MarkConfig.Value.UnlockMarkPic : this.MarkConfig.Value.LockMarkPic);
				return;
			}
			this.IconPath = this.MarkConfig.Value.LockMarkPic;
		}

		// Token: 0x060396A6 RID: 235174 RVA: 0x00E93BFC File Offset: 0x00E91DFC
		public bool IsRelativeFunctionOpen()
		{
			if (this.MarkConfig.Value.RelativeSubType <= 0)
			{
				return true;
			}
			MapMarkRelativeSubType? mapMarkFuncTypeConfigById = ConfigBase<MapConfig>.Instance.GetMapMarkFuncTypeConfigById(this.MarkConfig.Value.RelativeSubType);
			return mapMarkFuncTypeConfigById == null || mapMarkFuncTypeConfigById.Value.FunctionId <= 0 || ModelBase<FunctionModel>.Instance.IsOpen(mapMarkFuncTypeConfigById.Value.FunctionId);
		}

		// Token: 0x060396A7 RID: 235175 RVA: 0x00E93C75 File Offset: 0x00E91E75
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.ConfigMarkItemView;
		}

		// Token: 0x060396A8 RID: 235176 RVA: 0x00E93C78 File Offset: 0x00E91E78
		protected override MarkItemView CreateView()
		{
			return new ConfigMarkItemView(this);
		}

		// Token: 0x060396A9 RID: 235177 RVA: 0x00E93C80 File Offset: 0x00E91E80
		public override string GetLocaleDesc()
		{
			return this.MarkConfig.Value.MarkDesc;
		}

		// Token: 0x060396AA RID: 235178 RVA: 0x00E93CA0 File Offset: 0x00E91EA0
		public override string GetTitleText()
		{
			return ConfigBase<MapConfig>.Instance.GetLocalText(this.MarkConfig.Value.MarkTitle);
		}

		// Token: 0x060396AB RID: 235179 RVA: 0x00E93CCC File Offset: 0x00E91ECC
		[NullableContext(2)]
		public string GetAreaText()
		{
			if (!(base.TrackTarget is TTrackTarget_Int))
			{
				return null;
			}
			MapMark? mapMark;
			string[] array = ((ConfigBase<MapConfig>.Instance.GetConfigMark(this.MarkId) != null) ? mapMark.GetValueOrDefault().AreaShowText() : null) ?? Array.Empty<string>();
			if (array.Length != 0)
			{
				return string.Join("-", from item in array
				select ConfigBase<MapConfig>.Instance.GetLocalText(item));
			}
			return ModelBase<MapModel>.Instance.GetMarkAreaText(this.MapId, ((TTrackTarget_Int)base.TrackTarget).Value);
		}

		// Token: 0x060396AC RID: 235180 RVA: 0x00E93D74 File Offset: 0x00E91F74
		protected bool CheckInShowRange(float scale)
		{
			MapMark value = this.MarkConfig.Value;
			return (float)value.ShowRange(0) < scale && (float)value.ShowRange(1) > scale;
		}

		// Token: 0x1700927C RID: 37500
		// (get) Token: 0x060396AD RID: 235181 RVA: 0x00E93DA7 File Offset: 0x00E91FA7
		public bool IsConditionShouldShow
		{
			get
			{
				return this.ConditionShouldShow && (!this.IsServerSaveShowState || ModelBase<MapModel>.Instance.GetMarkExtraShowState(this.MarkId).ShowFlag != MapMarkShowFlag.Hide) && this.ConditionShouldShow;
			}
		}

		// Token: 0x1700927D RID: 37501
		// (get) Token: 0x060396AE RID: 235182 RVA: 0x00E93DDA File Offset: 0x00E91FDA
		public bool IsConditionShouldShowWithoutServerState
		{
			get
			{
				return this.ConditionShouldShow;
			}
		}

		// Token: 0x060396AF RID: 235183 RVA: 0x00E93DE4 File Offset: 0x00E91FE4
		protected void InitShowCondition()
		{
			int showCondition = this.MarkConfig.Value.ShowCondition;
			this.CachedShowConditionPositive = (showCondition > 0);
			if (showCondition < 0)
			{
				this.IsServerSaveShowState = true;
				return;
			}
			if (showCondition == 0)
			{
				this.ConditionShouldShow = true;
				return;
			}
			this.IsServerSaveShowState = false;
			this.ConditionShouldShow = ModelBase<MapModel>.Instance.IsMarkUnlockedByServer(this.MarkId);
		}

		// Token: 0x060396B0 RID: 235184 RVA: 0x00E93E44 File Offset: 0x00E92044
		public override bool CheckCanShowView()
		{
			if (!this.CanConditionShowView())
			{
				return base.IsTracked;
			}
			float currentMapShowScale = this.GetCurrentMapShowScale();
			bool flag = this.CheckInShowRange(currentMapShowScale) || base.IsTracked;
			if (base.MapType == EMapType.WorldMap)
			{
				bool isCanShowViewIntermediately = base.IsCanShowViewIntermediately;
				bool flag2 = flag || base.IsIgnoreScaleShow;
				if (isCanShowViewIntermediately != flag2)
				{
					base.NeedPlayShowOrHideSeq = (flag2 ? "ShowView" : "HideView");
				}
				return flag2;
			}
			return true;
		}

		// Token: 0x060396B1 RID: 235185 RVA: 0x00E93EB4 File Offset: 0x00E920B4
		private bool FinishPlayIsShow()
		{
			return this.MarkConfig.Value.FinishIsShow == 1 || ModelBase<WorldMapModel>.Instance.CompletedPlayPointMarkIsShow || !this.GamePlayIsFinish();
		}

		// Token: 0x060396B2 RID: 235186 RVA: 0x00E93EF0 File Offset: 0x00E920F0
		protected virtual bool GamePlayIsFinish()
		{
			return base.MarkItemEntity.GamePlay.IsFinish;
		}

		// Token: 0x060396B3 RID: 235187 RVA: 0x00E93F02 File Offset: 0x00E92102
		public bool IsGameplayHasReward()
		{
			return base.MarkItemEntity.GamePlay.GameplayRewardIdList.Count > 0;
		}

		// Token: 0x060396B4 RID: 235188 RVA: 0x00E93F1C File Offset: 0x00E9211C
		public override bool GamePlayIsDiscover()
		{
			int relativeDungeonId = this.MarkConfig.Value.RelativeDungeonId;
			int relativeId = this.MarkConfig.Value.RelativeId;
			return ModelBase<LevelPlayReportModel>.Instance.IsCommonLevelPlayDiscover(relativeDungeonId, relativeId);
		}

		// Token: 0x060396B5 RID: 235189 RVA: 0x00E93F60 File Offset: 0x00E92160
		public bool CanConditionShowView()
		{
			EMapType mapType = base.MapType;
			int mapShow = this.MarkConfig.Value.MapShow;
			if ((mapShow == 1 && mapType != EMapType.MiniMap) || (mapShow == 2 && mapType == EMapType.MiniMap))
			{
				return false;
			}
			if (base.MarkItemEntity.IsTempMapMark && base.IsTempMapMarkShow())
			{
				return true;
			}
			if (this.CachedShowConditionPositive)
			{
				this.ConditionShouldShow = ModelBase<MapModel>.Instance.IsMarkUnlockedByServer(this.MarkId);
			}
			return this.ConditionShouldShow && (!this.IsServerSaveShowState || ModelBase<MapModel>.Instance.GetMarkExtraShowState(this.MarkId).ShowFlag != MapMarkShowFlag.Hide) && this.IsFogUnlock && this.FinishPlayIsShow();
		}

		// Token: 0x060396B6 RID: 235190 RVA: 0x00E94010 File Offset: 0x00E92210
		public override float GetShowScale()
		{
			return (float)this.MarkConfig.Value.ShowRange(0) + (float)this.MarkConfig.Value.ShowRange(1) / 2f;
		}

		// Token: 0x060396B7 RID: 235191 RVA: 0x00E94050 File Offset: 0x00E92250
		public bool IsLordGym()
		{
			return this.MarkConfig.Value.RelativeSubType == 3;
		}

		// Token: 0x060396B8 RID: 235192 RVA: 0x00E94074 File Offset: 0x00E92274
		public bool IsNewLordGym()
		{
			return this.MarkConfig.Value.RelativeSubType == 8;
		}

		// Token: 0x060396B9 RID: 235193 RVA: 0x00E94098 File Offset: 0x00E92298
		public bool IsMoraleFlag()
		{
			return this.MarkConfig.Value.RelativeSubType == 6;
		}

		// Token: 0x060396BA RID: 235194 RVA: 0x00E940BC File Offset: 0x00E922BC
		public bool IsNightMareFlag()
		{
			return this.MarkConfig.Value.RelativeSubType == 9;
		}

		// Token: 0x060396BB RID: 235195 RVA: 0x00E940E0 File Offset: 0x00E922E0
		public bool IsVisionSettlementFlag()
		{
			return this.MarkConfig.Value.RelativeSubType == 10;
		}

		// Token: 0x060396BC RID: 235196 RVA: 0x00E94104 File Offset: 0x00E92304
		public bool IsFlagChallengeFlag()
		{
			return this.MarkConfig.Value.RelativeSubType == 7;
		}

		// Token: 0x060396BD RID: 235197 RVA: 0x00E94128 File Offset: 0x00E92328
		public void ChangeSubMap(int floorIndex)
		{
			bool flag;
			if (this.LocateInGround() && floorIndex == 0)
			{
				flag = true;
			}
			else
			{
				int multiMapId = this.GetMultiMapId();
				int? worldMapCurrentMultiMapId = ModelBase<WorldMapModel>.Instance.WorldMapCurrentMultiMapId;
				flag = (multiMapId == worldMapCurrentMultiMapId.GetValueOrDefault() & worldMapCurrentMultiMapId != null);
			}
			if (base.IsSelectThisFloor == flag)
			{
				return;
			}
			base.IsSelectThisFloor = flag;
			this.UpdateViewIcon();
		}

		// Token: 0x060396BE RID: 235198 RVA: 0x00E94180 File Offset: 0x00E92380
		protected void UpdateViewIcon()
		{
			if (base.View != null && !base.IsDestroy)
			{
				ConfigMarkItemView configMarkItemView = base.View as ConfigMarkItemView;
				if (configMarkItemView.ViewInitialized)
				{
					configMarkItemView.UpdateIcon();
				}
			}
		}

		// Token: 0x04020A3E RID: 133694
		public MapMark? MarkConfig;

		// Token: 0x04020A3F RID: 133695
		protected int InnerMarkId;

		// Token: 0x04020A40 RID: 133696
		protected bool IsServerSaveShowState;

		// Token: 0x04020A41 RID: 133697
		private bool CachedShowConditionPositive;

		// Token: 0x04020A42 RID: 133698
		protected bool ConditionShouldShow = true;
	}
}

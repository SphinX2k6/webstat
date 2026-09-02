using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C6A RID: 23658
	[NullableContext(1)]
	[Nullable(0)]
	public class InfrRoadNetworkMapPanel : UiPanelBase
	{
		// Token: 0x0603BC7C RID: 244860 RVA: 0x00F26BE8 File Offset: 0x00F24DE8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 54;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(32, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(33, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(34, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(35, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(36, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(37, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(38, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(39, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(40, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(41, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(42, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(52, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(53, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(54, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(55, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(56, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(57, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(58, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(59, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(60, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(61, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(62, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603BC7D RID: 244861 RVA: 0x00F27334 File Offset: 0x00F25534
		protected override UniTask OnBeforeStartAsync()
		{
			InfrRoadNetworkMapPanel.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<InfrRoadNetworkMapPanel.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC7E RID: 244862 RVA: 0x00F27378 File Offset: 0x00F25578
		private List<int> GetRoadIdList()
		{
			return (from config in ConfigBase<InfrastructureConfig>.Instance.GetRoadConfigList()
			select config.Id into id
			orderby id
			select id).ToList<int>();
		}

		// Token: 0x0603BC7F RID: 244863 RVA: 0x00F273DC File Offset: 0x00F255DC
		private UniTask CreateMarkPanels()
		{
			InfrRoadNetworkMapPanel.<CreateMarkPanels>d__19 <CreateMarkPanels>d__;
			<CreateMarkPanels>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateMarkPanels>d__.<>4__this = this;
			<CreateMarkPanels>d__.<>1__state = -1;
			<CreateMarkPanels>d__.<>t__builder.Start<InfrRoadNetworkMapPanel.<CreateMarkPanels>d__19>(ref <CreateMarkPanels>d__);
			return <CreateMarkPanels>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC80 RID: 244864 RVA: 0x00F27420 File Offset: 0x00F25620
		private UniTask CreateObservatoryMark()
		{
			InfrRoadNetworkMapPanel.<CreateObservatoryMark>d__20 <CreateObservatoryMark>d__;
			<CreateObservatoryMark>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateObservatoryMark>d__.<>4__this = this;
			<CreateObservatoryMark>d__.<>1__state = -1;
			<CreateObservatoryMark>d__.<>t__builder.Start<InfrRoadNetworkMapPanel.<CreateObservatoryMark>d__20>(ref <CreateObservatoryMark>d__);
			return <CreateObservatoryMark>d__.<>t__builder.Task;
		}

		// Token: 0x0603BC81 RID: 244865 RVA: 0x00F27464 File Offset: 0x00F25664
		protected override void OnStart()
		{
			float value = ConfigCommonParamById.GetFloatConfig("InfrRoadNetworkMarkBaseScale").Value;
			this.TempVector.Set((double)value, (double)value, (double)value);
			InfrastructureDefine.IInfrRoadNetworkOpenParam infrRoadNetworkOpenParam = this.OpenParam as InfrastructureDefine.IInfrRoadNetworkOpenParam;
			if (infrRoadNetworkOpenParam != null)
			{
				this.SetNeedPlayFinishSeq(infrRoadNetworkOpenParam.NeedPlayFinishSeq.GetValueOrDefault(), infrRoadNetworkOpenParam.RoadId, infrRoadNetworkOpenParam.DeliveryType);
			}
			this.RefreshAllMarks();
			this.RefreshAllRoad();
		}

		// Token: 0x0603BC82 RID: 244866 RVA: 0x00F274D0 File Offset: 0x00F256D0
		public void RefreshAllMarks()
		{
			foreach (KeyValuePair<int, InfrRoadNetworkMarkItem> keyValuePair in this.MarkItemMap)
			{
				int key = keyValuePair.Key;
				InfrRoadNetworkMarkItem value = keyValuePair.Value;
				value.SetNeedPlayFinishSeq(this.NeedPlayFinishSeq && this.FinishDeliveryType == ActionInfrastructureItemDeliveryType.Road, this.FinishRoadId);
				value.Refresh(key);
			}
			this.ObservatoryMarkItem.SetNeedPlayFinishSeq(this.NeedPlayFinishSeq && this.FinishDeliveryType == ActionInfrastructureItemDeliveryType.Observatory);
		}

		// Token: 0x0603BC83 RID: 244867 RVA: 0x00F27570 File Offset: 0x00F25770
		private void RefreshAllRoad()
		{
			List<int> roadIdList = this.GetRoadIdList();
			int i;
			for (i = 0; i < roadIdList.Count; i++)
			{
				int num = roadIdList[i];
				InfrastructureDefine.IInfrRoadData roadDataByRoadId = ModelBase<InfrastructureModel>.Instance.GetRoadDataByRoadId(num);
				if (roadDataByRoadId != null && roadDataByRoadId.Status == InfrStatusPb.InfrStatusComplete)
				{
					if (this.FinishRoadId == num && this.FinishDeliveryType == ActionInfrastructureItemDeliveryType.Road)
					{
						UUIItem item = base.GetItem(this.TextureLineList[i]);
						if (item != null)
						{
							item.SetUIActive(false);
						}
						UUIItem item2 = base.GetItem(this.TextureStaticLineList[i]);
						if (item2 != null)
						{
							item2.SetUIActive(false);
						}
					}
					else
					{
						UUIItem item3 = base.GetItem(this.TextureLineList[i]);
						if (item3 != null)
						{
							item3.SetUIActive(false);
						}
						UUIItem item4 = base.GetItem(this.TextureStaticLineList[i]);
						if (item4 != null)
						{
							item4.SetUIActive(true);
						}
					}
					if (this.TextureLineList[i] == 21)
					{
						UUIItem item5 = base.GetItem(52);
						if (item5 != null)
						{
							item5.SetUIActive(false);
						}
					}
				}
				else
				{
					UUIItem item6 = base.GetItem(this.TextureLineList[i]);
					if (item6 != null)
					{
						item6.SetUIActive(false);
					}
					UUIItem item7 = base.GetItem(this.TextureStaticLineList[i]);
					if (item7 != null)
					{
						item7.SetUIActive(false);
					}
				}
			}
			while (i < this.TextureLineList.Count && i < this.MarkItemList.Count)
			{
				UUIItem item8 = base.GetItem(this.TextureLineList[i]);
				if (item8 != null)
				{
					item8.SetUIActive(false);
				}
				UUIItem item9 = base.GetItem(this.MarkItemList[i]);
				if (item9 != null)
				{
					item9.SetUIActive(false);
				}
				i++;
			}
		}

		// Token: 0x0603BC84 RID: 244868 RVA: 0x00F27710 File Offset: 0x00F25910
		private void OnClickMark(int roadId)
		{
			if (this.SelectedType == InfrRoadNetworkMapPanel.ESelectedType.Road)
			{
				InfrRoadNetworkMarkItem infrRoadNetworkMarkItem;
				if (this.MarkItemMap.TryGetValue(this.SelectedRoadId, out infrRoadNetworkMarkItem))
				{
					infrRoadNetworkMarkItem.SetSelected(false);
					int num = this.GetRoadIdList().IndexOf(this.SelectedRoadId);
					if (num >= 0)
					{
						UUIItem item = base.GetItem(this.TextureLineSweepList[num]);
						if (item != null)
						{
							item.SetUIActive(false);
						}
						UUIItem item2 = base.GetItem(this.TextureLineDashedSweepList[num]);
						if (item2 != null)
						{
							item2.SetUIActive(false);
						}
					}
				}
			}
			else if (this.SelectedType == InfrRoadNetworkMapPanel.ESelectedType.Observatory)
			{
				this.ObservatoryMarkItem.SetSelected(false);
			}
			this.SelectedType = InfrRoadNetworkMapPanel.ESelectedType.Road;
			this.SelectedRoadId = roadId;
			InfrRoadNetworkMarkItem infrRoadNetworkMarkItem2;
			this.MarkItemMap.TryGetValue(roadId, out infrRoadNetworkMarkItem2);
			List<int> roadIdList = this.GetRoadIdList();
			InfrastructureDefine.IInfrRoadData roadDataByRoadId = ModelBase<InfrastructureModel>.Instance.GetRoadDataByRoadId(roadId);
			int num2 = roadIdList.IndexOf(roadId);
			if (num2 >= 0)
			{
				if (roadDataByRoadId != null && roadDataByRoadId.Status == InfrStatusPb.InfrStatusComplete)
				{
					UUIItem item3 = base.GetItem(this.TextureLineSweepList[num2]);
					if (item3 != null)
					{
						item3.SetUIActive(true);
					}
				}
				else
				{
					UUIItem item4 = base.GetItem(this.TextureLineDashedSweepList[num2]);
					if (item4 != null)
					{
						item4.SetUIActive(true);
					}
				}
			}
			if (infrRoadNetworkMarkItem2 != null)
			{
				infrRoadNetworkMarkItem2.Refresh(roadId);
			}
			Action<InfrastructureDefine.IInfrMaterialsDeliveryOpenParam> onClickMarkCb = this.OnClickMarkCb;
			if (onClickMarkCb == null)
			{
				return;
			}
			onClickMarkCb(new InfrastructureDefine.InfrMaterialsDeliveryOpenParam
			{
				DeliveryType = ActionInfrastructureItemDeliveryType.Road,
				RoadId = roadId,
				OpenSource = InfrastructureDefine.EMaterialDeliveryOpenSource.RoadNetworkMap
			});
		}

		// Token: 0x0603BC85 RID: 244869 RVA: 0x00F27868 File Offset: 0x00F25A68
		private void OnClickObservatoryMark()
		{
			if (this.SelectedType == InfrRoadNetworkMapPanel.ESelectedType.Observatory)
			{
				return;
			}
			InfrRoadNetworkMarkItem infrRoadNetworkMarkItem;
			if (this.SelectedType == InfrRoadNetworkMapPanel.ESelectedType.Road && this.MarkItemMap.TryGetValue(this.SelectedRoadId, out infrRoadNetworkMarkItem))
			{
				infrRoadNetworkMarkItem.SetSelected(false);
			}
			this.SelectedType = InfrRoadNetworkMapPanel.ESelectedType.Observatory;
			this.ObservatoryMarkItem.Refresh();
			Action<InfrastructureDefine.IInfrMaterialsDeliveryOpenParam> onClickMarkCb = this.OnClickMarkCb;
			if (onClickMarkCb == null)
			{
				return;
			}
			onClickMarkCb(new InfrastructureDefine.InfrMaterialsDeliveryOpenParam
			{
				DeliveryType = ActionInfrastructureItemDeliveryType.Observatory,
				RoadId = this.SelectedRoadId,
				OpenSource = InfrastructureDefine.EMaterialDeliveryOpenSource.RoadNetworkMap
			});
		}

		// Token: 0x0603BC86 RID: 244870 RVA: 0x00F278E5 File Offset: 0x00F25AE5
		public void SetOnClickMarkCb(Action<InfrastructureDefine.IInfrMaterialsDeliveryOpenParam> cb)
		{
			this.OnClickMarkCb = cb;
		}

		// Token: 0x0603BC87 RID: 244871 RVA: 0x00F278EE File Offset: 0x00F25AEE
		public void SetNeedPlayFinishSeq(bool needPlayFinishSeq, int roadId, ActionInfrastructureItemDeliveryType deliveryType)
		{
			this.NeedPlayFinishSeq = needPlayFinishSeq;
			this.FinishRoadId = roadId;
			this.FinishDeliveryType = deliveryType;
		}

		// Token: 0x0603BC88 RID: 244872 RVA: 0x00F27908 File Offset: 0x00F25B08
		public void SelectMark(ActionInfrastructureItemDeliveryType deliveryType, int roadId)
		{
			if (deliveryType == ActionInfrastructureItemDeliveryType.Road)
			{
				InfrRoadNetworkMarkItem infrRoadNetworkMarkItem;
				if (this.MarkItemMap.TryGetValue(roadId, out infrRoadNetworkMarkItem))
				{
					infrRoadNetworkMarkItem.SetSelected(true);
					int num = this.GetRoadIdList().IndexOf(roadId);
					if (num >= 0)
					{
						InfrastructureDefine.IInfrRoadData roadDataByRoadId = ModelBase<InfrastructureModel>.Instance.GetRoadDataByRoadId(roadId);
						if (roadDataByRoadId != null && roadDataByRoadId.Status == InfrStatusPb.InfrStatusComplete)
						{
							UUIItem item = base.GetItem(this.TextureLineSweepList[num]);
							if (item == null)
							{
								return;
							}
							item.SetUIActive(true);
							return;
						}
						else
						{
							UUIItem item2 = base.GetItem(this.TextureLineDashedSweepList[num]);
							if (item2 == null)
							{
								return;
							}
							item2.SetUIActive(true);
							return;
						}
					}
				}
			}
			else if (deliveryType == ActionInfrastructureItemDeliveryType.Observatory)
			{
				this.ObservatoryMarkItem.SetSelected(true);
			}
		}

		// Token: 0x0603BC89 RID: 244873 RVA: 0x00F279AC File Offset: 0x00F25BAC
		public void DeselectMark()
		{
			if (this.SelectedType == InfrRoadNetworkMapPanel.ESelectedType.Road)
			{
				InfrRoadNetworkMarkItem infrRoadNetworkMarkItem;
				if (this.MarkItemMap.TryGetValue(this.SelectedRoadId, out infrRoadNetworkMarkItem))
				{
					infrRoadNetworkMarkItem.SetSelected(false);
					int num = this.GetRoadIdList().IndexOf(this.SelectedRoadId);
					if (num >= 0)
					{
						UUIItem item = base.GetItem(this.TextureLineSweepList[num]);
						if (item != null)
						{
							item.SetUIActive(false);
						}
						UUIItem item2 = base.GetItem(this.TextureLineDashedSweepList[num]);
						if (item2 != null)
						{
							item2.SetUIActive(false);
						}
					}
				}
			}
			else if (this.SelectedType == InfrRoadNetworkMapPanel.ESelectedType.Observatory)
			{
				this.ObservatoryMarkItem.SetSelected(false);
			}
			this.SelectedType = InfrRoadNetworkMapPanel.ESelectedType.None;
			this.SelectedRoadId = -1;
		}

		// Token: 0x0603BC8A RID: 244874 RVA: 0x00F27A58 File Offset: 0x00F25C58
		public Tuple<float, float> GetMarkUiPosition(int roadId)
		{
			InfrRoadNetworkMarkItem infrRoadNetworkMarkItem;
			if (this.MarkItemMap.TryGetValue(roadId, out infrRoadNetworkMarkItem))
			{
				UUIItem rootItem = infrRoadNetworkMarkItem.GetRootItem();
				FVector2D? fvector2D = (rootItem != null) ? new FVector2D?(rootItem.GetAnchorOffset()) : null;
				return new Tuple<float, float>(fvector2D.Value.X, fvector2D.Value.Y);
			}
			return new Tuple<float, float>(0f, 0f);
		}

		// Token: 0x0603BC8B RID: 244875 RVA: 0x00F27AC4 File Offset: 0x00F25CC4
		public Tuple<float, float> GetObservatoryMarkUiPosition()
		{
			UUIItem rootItem = this.ObservatoryMarkItem.GetRootItem();
			FVector2D? fvector2D = (rootItem != null) ? new FVector2D?(rootItem.GetAnchorOffset()) : null;
			return new Tuple<float, float>(fvector2D.Value.X, fvector2D.Value.Y);
		}

		// Token: 0x0603BC8C RID: 244876 RVA: 0x00F27B14 File Offset: 0x00F25D14
		public void RefreshMarkScale(float mapScale)
		{
			float value = ConfigCommonParamById.GetFloatConfig("InfrRoadNetworkMarkBaseScale").Value;
			global::Vector vector = global::Vector.Create((double)(value / mapScale), (double)(value / mapScale), (double)(value / mapScale));
			foreach (InfrRoadNetworkMarkItem infrRoadNetworkMarkItem in this.MarkItemMap.Values)
			{
				infrRoadNetworkMarkItem.GetRootItem().SetUIItemScale(vector.ToUeVectorOld());
			}
			this.ObservatoryMarkItem.GetRootItem().SetUIItemScale(vector.ToUeVectorOld());
		}

		// Token: 0x0603BC8D RID: 244877 RVA: 0x00F27BB0 File Offset: 0x00F25DB0
		public void ShowMarkFinishSeq(ActionInfrastructureItemDeliveryType deliveryType, int roadId, Action onFinishPlayEnd)
		{
			if (deliveryType == ActionInfrastructureItemDeliveryType.Road)
			{
				InfrRoadNetworkMarkItem infrRoadNetworkMarkItem;
				if (this.MarkItemMap.TryGetValue(roadId, out infrRoadNetworkMarkItem))
				{
					infrRoadNetworkMarkItem.ShowMarkFinish(delegate
					{
						int num = this.GetRoadIdList().IndexOf(roadId);
						if (num >= 0 && this.TextureLineList[num] == 21)
						{
							UUIItem item = this.GetItem(52);
							if (item != null)
							{
								item.SetUIActive(false);
							}
						}
						Action onFinishPlayEnd2 = onFinishPlayEnd;
						if (onFinishPlayEnd2 == null)
						{
							return;
						}
						onFinishPlayEnd2();
					});
					return;
				}
			}
			else if (deliveryType == ActionInfrastructureItemDeliveryType.Observatory)
			{
				this.ObservatoryMarkItem.ShowMarkFinish(delegate
				{
					Action onFinishPlayEnd2 = onFinishPlayEnd;
					if (onFinishPlayEnd2 == null)
					{
						return;
					}
					onFinishPlayEnd2();
				});
			}
		}

		// Token: 0x0603BC8E RID: 244878 RVA: 0x00F27C20 File Offset: 0x00F25E20
		public void RefreshFinishTextureLine(int roadId)
		{
			int num = this.GetRoadIdList().IndexOf(roadId);
			if (num >= 0)
			{
				UUIItem item = base.GetItem(this.TextureLineList[num]);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(true);
			}
		}

		// Token: 0x0603BC8F RID: 244879 RVA: 0x00F27C5C File Offset: 0x00F25E5C
		public void ShowMarkUnlock(bool needPlayFinishSeq, Action cb)
		{
			List<int> hasUnlockRoadAndNotPlaySeqMark = ModelBase<InfrastructureModel>.Instance.GetHasUnlockRoadAndNotPlaySeqMark();
			foreach (int key in hasUnlockRoadAndNotPlaySeqMark)
			{
				InfrRoadNetworkMarkItem infrRoadNetworkMarkItem;
				if (this.MarkItemMap.TryGetValue(key, out infrRoadNetworkMarkItem))
				{
					infrRoadNetworkMarkItem.ShowMarkUnlock(cb);
				}
			}
			if (hasUnlockRoadAndNotPlaySeqMark.Count == 0)
			{
				cb();
			}
			int fireLevel = ModelBase<InfrastructureModel>.Instance.FireLevel;
			int player = LocalStorage.GetPlayer<int>(ELocalStoragePlayerKey.InfrObservatoryLevelUpSeq, 0);
			if (fireLevel > player && !needPlayFinishSeq)
			{
				this.ObservatoryMarkItem.ShowLevelUpSeq();
			}
			LocalStorage.SetPlayer<int>(ELocalStoragePlayerKey.InfrObservatoryLevelUpSeq, ModelBase<InfrastructureModel>.Instance.FireLevel);
		}

		// Token: 0x0603BC90 RID: 244880 RVA: 0x00F27D10 File Offset: 0x00F25F10
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			if (configParams[0] == "RoadMark")
			{
				int key = int.Parse(configParams[1]);
				InfrRoadNetworkMarkItem infrRoadNetworkMarkItem;
				if (this.MarkItemMap.TryGetValue(key, out infrRoadNetworkMarkItem))
				{
					return infrRoadNetworkMarkItem.GetGuideUiItemAndUiItemForShowEx(configParams);
				}
			}
			return null;
		}

		// Token: 0x04021979 RID: 137593
		private readonly Dictionary<int, InfrRoadNetworkMarkItem> MarkItemMap = new Dictionary<int, InfrRoadNetworkMarkItem>();

		// Token: 0x0402197A RID: 137594
		private readonly InfrRoadNetworkObservatoryMarkItem ObservatoryMarkItem = new InfrRoadNetworkObservatoryMarkItem();

		// Token: 0x0402197B RID: 137595
		private int SelectedRoadId;

		// Token: 0x0402197C RID: 137596
		private InfrRoadNetworkMapPanel.ESelectedType SelectedType;

		// Token: 0x0402197D RID: 137597
		private Action<InfrastructureDefine.IInfrMaterialsDeliveryOpenParam> OnClickMarkCb;

		// Token: 0x0402197E RID: 137598
		private readonly global::Vector TempVector = global::Vector.Create();

		// Token: 0x0402197F RID: 137599
		private bool NeedPlayFinishSeq;

		// Token: 0x04021980 RID: 137600
		private int FinishRoadId;

		// Token: 0x04021981 RID: 137601
		private ActionInfrastructureItemDeliveryType FinishDeliveryType = ActionInfrastructureItemDeliveryType.Road;

		// Token: 0x04021982 RID: 137602
		private readonly List<int> MarkItemList = new List<int>
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			18,
			19
		};

		// Token: 0x04021983 RID: 137603
		private readonly List<int> TextureLineList = new List<int>
		{
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			17,
			20,
			21,
			22
		};

		// Token: 0x04021984 RID: 137604
		public readonly List<int> TextureStaticLineList = new List<int>
		{
			53,
			54,
			55,
			56,
			57,
			58,
			59,
			60,
			61,
			62
		};

		// Token: 0x04021985 RID: 137605
		private readonly List<int> TextureLineDashedSweepList = new List<int>
		{
			23,
			24,
			25,
			26,
			27,
			28,
			29,
			30,
			31,
			32
		};

		// Token: 0x04021986 RID: 137606
		public readonly List<int> TextureLineSweepList = new List<int>
		{
			33,
			34,
			35,
			36,
			37,
			38,
			39,
			40,
			41,
			42
		};

		// Token: 0x0200BD11 RID: 48401
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x0403A41A RID: 238618
			public const int MarkItem1 = 0;

			// Token: 0x0403A41B RID: 238619
			public const int MarkItem2 = 1;

			// Token: 0x0403A41C RID: 238620
			public const int MarkItem3 = 2;

			// Token: 0x0403A41D RID: 238621
			public const int MarkItem4 = 3;

			// Token: 0x0403A41E RID: 238622
			public const int MarkItem5 = 4;

			// Token: 0x0403A41F RID: 238623
			public const int MarkItem6 = 5;

			// Token: 0x0403A420 RID: 238624
			public const int MarkItem7 = 6;

			// Token: 0x0403A421 RID: 238625
			public const int MarkItem8 = 7;

			// Token: 0x0403A422 RID: 238626
			public const int MarkItem9 = 8;

			// Token: 0x0403A423 RID: 238627
			public const int ObservatoryMarkItem = 9;

			// Token: 0x0403A424 RID: 238628
			public const int TextureLine1 = 10;

			// Token: 0x0403A425 RID: 238629
			public const int TextureLine2 = 11;

			// Token: 0x0403A426 RID: 238630
			public const int TextureLine3 = 12;

			// Token: 0x0403A427 RID: 238631
			public const int TextureLine4 = 13;

			// Token: 0x0403A428 RID: 238632
			public const int TextureLine5 = 14;

			// Token: 0x0403A429 RID: 238633
			public const int TextureLine6 = 15;

			// Token: 0x0403A42A RID: 238634
			public const int TextureLine7 = 16;

			// Token: 0x0403A42B RID: 238635
			public const int TextureLine8 = 17;

			// Token: 0x0403A42C RID: 238636
			public const int MarkItem10 = 18;

			// Token: 0x0403A42D RID: 238637
			public const int MarkItem11 = 19;

			// Token: 0x0403A42E RID: 238638
			public const int TextureLine9 = 20;

			// Token: 0x0403A42F RID: 238639
			public const int TextureLine10 = 21;

			// Token: 0x0403A430 RID: 238640
			public const int TextureLine11 = 22;

			// Token: 0x0403A431 RID: 238641
			public const int TextureLineDashedSweep1 = 23;

			// Token: 0x0403A432 RID: 238642
			public const int TextureLineDashedSweep2 = 24;

			// Token: 0x0403A433 RID: 238643
			public const int TextureLineDashedSweep3 = 25;

			// Token: 0x0403A434 RID: 238644
			public const int TextureLineDashedSweep4 = 26;

			// Token: 0x0403A435 RID: 238645
			public const int TextureLineDashedSweep5 = 27;

			// Token: 0x0403A436 RID: 238646
			public const int TextureLineDashedSweep6 = 28;

			// Token: 0x0403A437 RID: 238647
			public const int TextureLineDashedSweep7 = 29;

			// Token: 0x0403A438 RID: 238648
			public const int TextureLineDashedSweep8 = 30;

			// Token: 0x0403A439 RID: 238649
			public const int TextureLineDashedSweep9 = 31;

			// Token: 0x0403A43A RID: 238650
			public const int TextureLineDashedSweep10 = 32;

			// Token: 0x0403A43B RID: 238651
			public const int TextureLineSweep1 = 33;

			// Token: 0x0403A43C RID: 238652
			public const int TextureLineSweep2 = 34;

			// Token: 0x0403A43D RID: 238653
			public const int TextureLineSweep3 = 35;

			// Token: 0x0403A43E RID: 238654
			public const int TextureLineSweep4 = 36;

			// Token: 0x0403A43F RID: 238655
			public const int TextureLineSweep5 = 37;

			// Token: 0x0403A440 RID: 238656
			public const int TextureLineSweep6 = 38;

			// Token: 0x0403A441 RID: 238657
			public const int TextureLineSweep7 = 39;

			// Token: 0x0403A442 RID: 238658
			public const int TextureLineSweep8 = 40;

			// Token: 0x0403A443 RID: 238659
			public const int TextureLineSweep9 = 41;

			// Token: 0x0403A444 RID: 238660
			public const int TextureLineSweep10 = 42;

			// Token: 0x0403A445 RID: 238661
			public const int TextureLineDotted10 = 52;

			// Token: 0x0403A446 RID: 238662
			public const int TextureStaticLine1 = 53;

			// Token: 0x0403A447 RID: 238663
			public const int TextureStaticLine2 = 54;

			// Token: 0x0403A448 RID: 238664
			public const int TextureStaticLine3 = 55;

			// Token: 0x0403A449 RID: 238665
			public const int TextureStaticLine4 = 56;

			// Token: 0x0403A44A RID: 238666
			public const int TextureStaticLine5 = 57;

			// Token: 0x0403A44B RID: 238667
			public const int TextureStaticLine6 = 58;

			// Token: 0x0403A44C RID: 238668
			public const int TextureStaticLine7 = 59;

			// Token: 0x0403A44D RID: 238669
			public const int TextureStaticLine8 = 60;

			// Token: 0x0403A44E RID: 238670
			public const int TextureStaticLine9 = 61;

			// Token: 0x0403A44F RID: 238671
			public const int TextureStaticLine10 = 62;
		}

		// Token: 0x0200BD12 RID: 48402
		[NullableContext(0)]
		private enum ESelectedType
		{
			// Token: 0x0403A451 RID: 238673
			None,
			// Token: 0x0403A452 RID: 238674
			Road,
			// Token: 0x0403A453 RID: 238675
			Observatory
		}
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using CSharpScript.Game.World.Controller;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005F95 RID: 24469
	[NullableContext(1)]
	[Nullable(0)]
	public class AlterMarksView : BattleChildView
	{
		// Token: 0x0603D6E2 RID: 251618 RVA: 0x00FA13D4 File Offset: 0x00F9F5D4
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			this.BindMarksEvents();
			this.BindStalkEvents();
			this.BindEavesdropEvents();
			this.ProcessPendingMarkInfo();
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnChangeRole));
			Singleton<EventSystem>.Instance.Add<bool, long>(EEventName.OnSneakFoundChange, new Action<bool, long>(this.OnFoundStateChange));
			Singleton<EventSystem>.Instance.Add(EEventName.SneakStart, new Action(this.OnSneakStart));
			Singleton<EventSystem>.Instance.Add(EEventName.SneakEnd, new Action(this.OnSneakEnd));
			ModelBase<AlertMarkModel>.Instance.AlertMarkInit = true;
			if (ConfigCommonParamById.GetBoolConfig("ShowSneakMask").GetValueOrDefault())
			{
				UUIItem layerRootUiItem = Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.HUD);
				Singleton<LguiUtil>.Instance.LoadPrefabByResourceIdAsync("UiItem_Sneakzhezhao", layerRootUiItem, null, ResourceSystem.EResourceLoadPriority.Default, "js_undefined").ContinueWith(delegate(AActor actor)
				{
					if (actor == null)
					{
						return;
					}
					this.MaskItem = (actor.GetComponentByClass(UUIItem.StaticClass()) as UUIItem);
					UUIItem maskItem = this.MaskItem;
					if (maskItem != null)
					{
						maskItem.SetHierarchyIndex(0);
					}
					UUIItem maskItem2 = this.MaskItem;
					if (maskItem2 == null)
					{
						return;
					}
					maskItem2.SetUIActive(false);
				}).Forget();
			}
			this.TimeItem = new AlterTime();
			this.TimeItem.CreateByResourceIdAsync("UiItem_Sneakshijian", this.RootItem, false).Forget();
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			this.UpdateListenTagTask(curRoleData);
			this.SetActive(false);
		}

		// Token: 0x0603D6E3 RID: 251619 RVA: 0x00FA150C File Offset: 0x00F9F70C
		[NullableContext(2)]
		private void UpdateListenTagTask(BattleUiRoleData roleData)
		{
			ITagTask listenTagTask = this.ListenTagTask;
			if (listenTagTask != null)
			{
				listenTagTask.EndTask();
			}
			BaseTagComponent baseTagComponent = (roleData != null) ? roleData.GameplayTagComponent : null;
			if (baseTagComponent == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCommon, ELogAuthor.CH, "获取当前角色BaseTagComponent失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.ListenTagTask = baseTagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.潜行状态"]), new BaseTagComponent.TTagSwitchedCallback(this.OnTagChange), AlterMarksView.ListenTagStat);
		}

		// Token: 0x0603D6E4 RID: 251620 RVA: 0x00FA1588 File Offset: 0x00F9F788
		public override void Reset()
		{
			base.Reset();
			this.UnbindMarksEvents();
			this.UnbindStalkEvents();
			this.UnbindEavesdropEvents();
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnChangeRole));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSneakFoundChange, new Action<bool, long>(this.OnFoundStateChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.SneakStart, new Action(this.OnSneakStart));
			Singleton<EventSystem>.Instance.Remove(EEventName.SneakEnd, new Action(this.OnSneakEnd));
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnChildQuestNodeFinish, new Action(this.OnFinish)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnChildQuestNodeFinish, new Action(this.OnFinish));
			}
			if (this.CurPlayerEntity != null)
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(this.CurPlayerEntity.Entity, EEventName.AiHateAddOrRemove, new Action<bool, AiController>(this.OnAiHateChanged));
				this.CurPlayerEntity = null;
			}
			foreach (AlterMark alterMark in this.AlterMarks.Values)
			{
				alterMark.Destroy(null);
			}
			this.AlterMarks.Clear();
			foreach (StalkAlertMark stalkAlertMark in this.StalkAlertMarks.Values)
			{
				stalkAlertMark.Destroy(null);
			}
			this.StalkAlertMarks.Clear();
		}

		// Token: 0x0603D6E5 RID: 251621 RVA: 0x00FA1730 File Offset: 0x00F9F930
		public void Update(float delta)
		{
			this.UpdateAddMark();
			foreach (AlterMark alterMark in this.AlterMarks.Values)
			{
				alterMark.Update();
			}
			foreach (AlterTipMark alterTipMark in this.AlterTipMarks.Values)
			{
				alterTipMark.Update();
			}
			foreach (EavesdropMark eavesdropMark in this.EavesdropMarks.Values)
			{
				eavesdropMark.Update();
			}
			foreach (StalkAlertMark stalkAlertMark in this.StalkAlertMarks.Values)
			{
				if (stalkAlertMark.CheckShowUiCondition())
				{
					stalkAlertMark.Update();
				}
			}
			if (this.IsCountdown)
			{
				this.CurTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp() / (double)Singleton<TimeUtil>.Instance.InverseMillisecond;
				this.CountdownTime = ((double)this.EndTimeStamp - this.CurTimeStamp) * (double)Singleton<TimeUtil>.Instance.InverseMillisecond;
				if (this.CountdownTime < 0.0)
				{
					this.HideCountdown();
					return;
				}
				this.TimeItem.SetCountdownText(this.CountdownTime);
			}
		}

		// Token: 0x0603D6E6 RID: 251622 RVA: 0x00FA18D4 File Offset: 0x00F9FAD4
		private void UpdateAddMark()
		{
			foreach (KeyValuePair<int, AlterMarksView.WaitOperationUnit> keyValuePair in this.WaitOperationMarks)
			{
				int num;
				AlterMarksView.WaitOperationUnit waitOperationUnit;
				keyValuePair.Deconstruct(out num, out waitOperationUnit);
				int num2 = num;
				AlterMarksView.WaitOperationUnit waitOperationUnit2 = waitOperationUnit;
				if (waitOperationUnit2.Type == AlterMarksView.EOperationType.Add)
				{
					AlterMark value = new AlterMark(this.RootItem, waitOperationUnit2.OriginPosition ?? global::Vector.Create(), waitOperationUnit2.TrackActor);
					this.AlterMarks[num2] = value;
					this.AddStalkAlertMark(num2, waitOperationUnit2.TrackActor);
				}
				else
				{
					AlterMark alterMark;
					if (this.AlterMarks.Remove(num2, out alterMark))
					{
						alterMark.Destroy(null);
					}
					this.RemoveStalkAlertMark(num2);
				}
			}
			this.WaitOperationMarks.Clear();
		}

		// Token: 0x0603D6E7 RID: 251623 RVA: 0x00FA19A8 File Offset: 0x00F9FBA8
		private void AddMark(int id, global::Vector originPosition, AActor trackActor)
		{
			if (!this.AlterMarks.ContainsKey(id))
			{
				AlterMarksView.WaitOperationUnit waitOperationUnit;
				if (this.WaitOperationMarks.TryGetValue(id, out waitOperationUnit))
				{
					if (waitOperationUnit.Type == AlterMarksView.EOperationType.Delete)
					{
						this.WaitOperationMarks.Remove(id);
						return;
					}
				}
				else
				{
					this.WaitOperationMarks[id] = new AlterMarksView.WaitOperationUnit
					{
						Type = AlterMarksView.EOperationType.Add,
						OriginPosition = originPosition,
						TrackActor = trackActor
					};
				}
			}
		}

		// Token: 0x0603D6E8 RID: 251624 RVA: 0x00FA1A10 File Offset: 0x00F9FC10
		private void RemoveMark(int id)
		{
			bool flag = this.AlterMarks.ContainsKey(id);
			bool flag2 = this.WaitOperationMarks.ContainsKey(id);
			if (!flag && !flag2)
			{
				return;
			}
			if (flag2)
			{
				this.WaitOperationMarks.Remove(id);
				return;
			}
			if (flag)
			{
				this.WaitOperationMarks[id] = new AlterMarksView.WaitOperationUnit
				{
					Type = AlterMarksView.EOperationType.Delete,
					OriginPosition = null,
					TrackActor = null
				};
			}
		}

		// Token: 0x0603D6E9 RID: 251625 RVA: 0x00FA1A78 File Offset: 0x00F9FC78
		private void AddStalkAlertMark(int id, AActor trackActor)
		{
			if (!this.StalkAlertMarks.ContainsKey(id))
			{
				StalkAlertMark stalkAlertMark = new StalkAlertMark(this.RootItem, trackActor);
				stalkAlertMark.InitEntityId(id);
				if (this.StalkAlertMarks.Count == 0)
				{
					this.SetActive(true);
				}
				this.StalkAlertMarks[id] = stalkAlertMark;
			}
		}

		// Token: 0x0603D6EA RID: 251626 RVA: 0x00FA1AC8 File Offset: 0x00F9FCC8
		private void RemoveStalkAlertMark(int id)
		{
			StalkAlertMark stalkAlertMark;
			if (this.StalkAlertMarks.TryGetValue(id, out stalkAlertMark))
			{
				stalkAlertMark.Destroy(null);
				this.StalkAlertMarks.Remove(id);
				if (this.StalkAlertMarks.Count == 0 && !ControllerBase<SneakController>.Instance.IsSneaking)
				{
					this.SetActive(false);
				}
			}
		}

		// Token: 0x0603D6EB RID: 251627 RVA: 0x00FA1B1C File Offset: 0x00F9FD1C
		private void AddEavesdropMark(int id, AActor trackActor, float showDist)
		{
			if (!this.EavesdropMarks.ContainsKey(id))
			{
				EavesdropMark eavesdropMark = new EavesdropMark(trackActor, id);
				eavesdropMark.Initialize(Singleton<UiLayer>.Instance.WorldSpaceUiRootItem, showDist);
				this.EavesdropMarks[id] = eavesdropMark;
			}
		}

		// Token: 0x0603D6EC RID: 251628 RVA: 0x00FA1B60 File Offset: 0x00F9FD60
		private void RemoveEavesdropMark(int id)
		{
			EavesdropMark eavesdropMark;
			if (this.EavesdropMarks.TryGetValue(id, out eavesdropMark))
			{
				eavesdropMark.Destroy(null);
				this.EavesdropMarks.Remove(id);
			}
		}

		// Token: 0x0603D6ED RID: 251629 RVA: 0x00FA1B94 File Offset: 0x00F9FD94
		private void OnEavesdropFound(int id)
		{
			foreach (KeyValuePair<int, EavesdropMark> keyValuePair in this.EavesdropMarks)
			{
				int num;
				EavesdropMark eavesdropMark;
				keyValuePair.Deconstruct(out num, out eavesdropMark);
				int num2 = num;
				EavesdropMark eavesdropMark2 = eavesdropMark;
				if (num2 == id)
				{
					eavesdropMark2.PlayFoundSeq();
				}
				else
				{
					eavesdropMark2.PlayEndSeq();
				}
			}
		}

		// Token: 0x0603D6EE RID: 251630 RVA: 0x00FA1C00 File Offset: 0x00F9FE00
		private void HideCountdown()
		{
			if (!this.IsCountdown)
			{
				return;
			}
			this.IsCountdown = false;
			this.TimeItem.SetUiActive(this.IsCountdown);
		}

		// Token: 0x0603D6EF RID: 251631 RVA: 0x00FA1C24 File Offset: 0x00F9FE24
		private void OnFoundStateChange(bool isFound, long endTimeStamp)
		{
			if (isFound)
			{
				if (!this.IsCountdown)
				{
					this.UnbindMarksEvents();
				}
				foreach (AlterMark alterMark in this.AlterMarks.Values)
				{
					alterMark.Destroy(null);
				}
				foreach (StalkAlertMark stalkAlertMark in this.StalkAlertMarks.Values)
				{
					stalkAlertMark.Destroy(null);
				}
				this.AlterMarks.Clear();
				this.StalkAlertMarks.Clear();
				this.IsCountdown = true;
				this.EndTimeStamp = endTimeStamp;
				if (!Singleton<EventSystem>.Instance.Has(EEventName.OnChildQuestNodeFinish, new Action(this.OnFinish)))
				{
					Singleton<EventSystem>.Instance.Add(EEventName.OnChildQuestNodeFinish, new Action(this.OnFinish));
				}
			}
			else
			{
				if (!this.IsBindMarkEvent)
				{
					this.BindMarksEvents();
				}
				this.IsCountdown = false;
			}
			this.TimeItem.SetUiActive(this.IsCountdown);
			this.OnBattleStateChanged(isFound);
		}

		// Token: 0x0603D6F0 RID: 251632 RVA: 0x00FA1D60 File Offset: 0x00F9FF60
		private void OnFinish()
		{
			this.HideCountdown();
		}

		// Token: 0x0603D6F1 RID: 251633 RVA: 0x00FA1D68 File Offset: 0x00F9FF68
		private void BindEavesdropEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.AddEavesdropMark, new Action<int, AActor, float>(this.AddEavesdropMark));
			Singleton<EventSystem>.Instance.Add(EEventName.RemoveEavesdropMark, new Action<int>(this.RemoveEavesdropMark));
			Singleton<EventSystem>.Instance.Add(EEventName.OnEavesdropFound, new Action<int>(this.OnEavesdropFound));
		}

		// Token: 0x0603D6F2 RID: 251634 RVA: 0x00FA1DCC File Offset: 0x00F9FFCC
		private void UnbindEavesdropEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.AddEavesdropMark, new Action<int, AActor, float>(this.AddEavesdropMark));
			Singleton<EventSystem>.Instance.Remove(EEventName.RemoveEavesdropMark, new Action<int>(this.RemoveEavesdropMark));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnEavesdropFound, new Action<int>(this.OnEavesdropFound));
		}

		// Token: 0x0603D6F3 RID: 251635 RVA: 0x00FA1E30 File Offset: 0x00FA0030
		private void BindStalkEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.AddStalkAlertMark, new Action<int, AActor>(this.AddStalkAlertMark));
			Singleton<EventSystem>.Instance.Add(EEventName.RemoveStalkAlertMark, new Action<int>(this.RemoveStalkAlertMark));
			Singleton<EventSystem>.Instance.Add(EEventName.OnStalkFound, new Action<int>(this.OnStalkFound));
			Singleton<EventSystem>.Instance.Add(EEventName.OnStalkFailed, new Action(this.OnStalkFailed));
		}

		// Token: 0x0603D6F4 RID: 251636 RVA: 0x00FA1EB0 File Offset: 0x00FA00B0
		private void UnbindStalkEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.AddStalkAlertMark, new Action<int, AActor>(this.AddStalkAlertMark));
			Singleton<EventSystem>.Instance.Remove(EEventName.RemoveStalkAlertMark, new Action<int>(this.RemoveStalkAlertMark));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnStalkFound, new Action<int>(this.OnStalkFound));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnStalkFailed, new Action(this.OnStalkFailed));
		}

		// Token: 0x0603D6F5 RID: 251637 RVA: 0x00FA1F30 File Offset: 0x00FA0130
		private void BindMarksEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.AddAlterMark, new Action<int, global::Vector, AActor>(this.AddMark));
			Singleton<EventSystem>.Instance.Add(EEventName.RemoveAlterMark, new Action<int>(this.RemoveMark));
			this.IsBindMarkEvent = true;
		}

		// Token: 0x0603D6F6 RID: 251638 RVA: 0x00FA1F7C File Offset: 0x00FA017C
		private void UnbindMarksEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.AddAlterMark, new Action<int, global::Vector, AActor>(this.AddMark));
			Singleton<EventSystem>.Instance.Remove(EEventName.RemoveAlterMark, new Action<int>(this.RemoveMark));
			this.IsBindMarkEvent = false;
		}

		// Token: 0x0603D6F7 RID: 251639 RVA: 0x00FA1FC8 File Offset: 0x00FA01C8
		private void OnTagChange(int tagId, bool tagExists)
		{
			UUIItem maskItem = this.MaskItem;
			if (maskItem == null)
			{
				return;
			}
			maskItem.SetUIActive(tagExists);
		}

		// Token: 0x0603D6F8 RID: 251640 RVA: 0x00FA1FDC File Offset: 0x00FA01DC
		private void OnChangeRole(int i, int i1)
		{
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			this.UpdateListenTagTask(curRoleData);
			if (this.CurPlayerEntity != null)
			{
				this.UpdateAiHateChangedEvent(curRoleData.EntityHandle);
			}
		}

		// Token: 0x0603D6F9 RID: 251641 RVA: 0x00FA200F File Offset: 0x00FA020F
		private void OnSneakStart()
		{
			this.SetActive(true);
		}

		// Token: 0x0603D6FA RID: 251642 RVA: 0x00FA2018 File Offset: 0x00FA0218
		private void OnSneakEnd()
		{
			if (this.StalkAlertMarks.Count == 0)
			{
				this.SetActive(false);
			}
		}

		// Token: 0x0603D6FB RID: 251643 RVA: 0x00FA2030 File Offset: 0x00FA0230
		private void OnBattleStateChanged(bool isInBattleState)
		{
			foreach (AlterTipMark alterTipMark in this.AlterTipMarks.Values)
			{
				alterTipMark.Destroy(null);
			}
			this.AlterTipMarks.Clear();
			if (isInBattleState)
			{
				if (!this.IsCountdown)
				{
					return;
				}
				if (this.CurPlayerEntity != null)
				{
					EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
					if (getCurrentEntity != this.CurPlayerEntity)
					{
						this.UpdateAiHateChangedEvent(getCurrentEntity);
					}
				}
				else
				{
					this.CurPlayerEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
					Singleton<EventSystem>.Instance.AddWithTarget(this.CurPlayerEntity.Entity, EEventName.AiHateAddOrRemove, new Action<bool, AiController>(this.OnAiHateChanged));
				}
				using (HashSet<int>.Enumerator enumerator2 = this.CurPlayerEntity.Entity.CheckGetComponent<CharacterUnifiedStateComponent>().GetAggroSet().GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						int num = enumerator2.Current;
						AActor owner = ModelBase<CreatureModel>.Instance.GetEntityById(num).Entity.CheckGetComponent<BaseActorComponent>().Owner;
						if (!this.AlterTipMarks.ContainsKey(num))
						{
							AlterTipMark alterTipMark2 = new AlterTipMark(this.RootItem, owner, true);
							this.AlterTipMarks[num] = alterTipMark2;
							alterTipMark2.ChangeToError();
						}
					}
					return;
				}
			}
			if (this.CurPlayerEntity != null)
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(this.CurPlayerEntity.Entity, EEventName.AiHateAddOrRemove, new Action<bool, AiController>(this.OnAiHateChanged));
				this.CurPlayerEntity = null;
			}
		}

		// Token: 0x0603D6FC RID: 251644 RVA: 0x00FA21CC File Offset: 0x00FA03CC
		private void OnAiHateChanged(bool addOrRemove, AiController from)
		{
			AActor owner = from.CharActorComp.Owner;
			int id = from.CharActorComp.Entity.Id;
			if (!this.AlterTipMarks.ContainsKey(id) && addOrRemove && this.IsCountdown)
			{
				AlterTipMark alterTipMark = new AlterTipMark(this.RootItem, owner, true);
				this.AlterTipMarks[id] = alterTipMark;
				alterTipMark.ChangeToError();
			}
		}

		// Token: 0x0603D6FD RID: 251645 RVA: 0x00FA2234 File Offset: 0x00FA0434
		private void UpdateAiHateChangedEvent(EntityHandle newEntityHandle)
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget(this.CurPlayerEntity.Entity, EEventName.AiHateAddOrRemove, new Action<bool, AiController>(this.OnAiHateChanged)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(this.CurPlayerEntity.Entity, EEventName.AiHateAddOrRemove, new Action<bool, AiController>(this.OnAiHateChanged));
				this.CurPlayerEntity = newEntityHandle;
				Singleton<EventSystem>.Instance.AddWithTarget(this.CurPlayerEntity.Entity, EEventName.AiHateAddOrRemove, new Action<bool, AiController>(this.OnAiHateChanged));
			}
		}

		// Token: 0x0603D6FE RID: 251646 RVA: 0x00FA22C0 File Offset: 0x00FA04C0
		private void OnStalkFound(int id)
		{
			StalkAlertMark stalkAlertMark;
			if (this.StalkAlertMarks.TryGetValue(id, out stalkAlertMark))
			{
				stalkAlertMark.SetAlertIcon("/Game/Aki/UI/UIResources/Common/Atlas/SP_ComIconSign.SP_ComIconSign");
				stalkAlertMark.StopUpdateAlertValue();
				stalkAlertMark.ActivateAlertEffect();
			}
		}

		// Token: 0x0603D6FF RID: 251647 RVA: 0x00FA22F4 File Offset: 0x00FA04F4
		private void OnStalkFailed()
		{
			foreach (StalkAlertMark stalkAlertMark in this.StalkAlertMarks.Values)
			{
				stalkAlertMark.Destroy(null);
			}
			this.StalkAlertMarks.Clear();
		}

		// Token: 0x0603D700 RID: 251648 RVA: 0x00FA2358 File Offset: 0x00FA0558
		public void ProcessPendingMarkInfo()
		{
			if (ModelBase<AlertMarkModel>.Instance.PendingMarkInfos.Count == 0)
			{
				return;
			}
			foreach (KeyValuePair<int, ValueTuple<AActor, EAlertnessType, float>> keyValuePair in ModelBase<AlertMarkModel>.Instance.PendingMarkInfos)
			{
				int num;
				ValueTuple<AActor, EAlertnessType, float> valueTuple;
				keyValuePair.Deconstruct(out num, out valueTuple);
				ValueTuple<AActor, EAlertnessType, float> valueTuple2 = valueTuple;
				int id = num;
				AActor item = valueTuple2.Item1;
				EAlertnessType item2 = valueTuple2.Item2;
				float item3 = valueTuple2.Item3;
				if (item2 != EAlertnessType.Stalk)
				{
					if (item2 == EAlertnessType.Eavesdrop)
					{
						this.AddEavesdropMark(id, item, item3);
					}
				}
				else
				{
					this.AddStalkAlertMark(id, item);
				}
			}
			ModelBase<AlertMarkModel>.Instance.PendingMarkInfos.Clear();
		}

		// Token: 0x0603D701 RID: 251649 RVA: 0x00FA2410 File Offset: 0x00FA0610
		public void OnBattleHudVisibleChanged(bool visible)
		{
			if (ControllerBase<SneakController>.Instance.IsSneaking)
			{
				this.SetActive(visible);
			}
		}

		// Token: 0x0402285D RID: 141405
		[StaticVariableRuleIgnore]
		private static readonly Stat ListenTagStat = Stat.Create("[AlterMarksView]ListenTag", "", "");

		// Token: 0x0402285E RID: 141406
		private readonly Dictionary<int, AlterMark> AlterMarks = new Dictionary<int, AlterMark>();

		// Token: 0x0402285F RID: 141407
		private readonly Dictionary<int, AlterTipMark> AlterTipMarks = new Dictionary<int, AlterTipMark>();

		// Token: 0x04022860 RID: 141408
		private readonly Dictionary<int, StalkAlertMark> StalkAlertMarks = new Dictionary<int, StalkAlertMark>();

		// Token: 0x04022861 RID: 141409
		private readonly Dictionary<int, EavesdropMark> EavesdropMarks = new Dictionary<int, EavesdropMark>();

		// Token: 0x04022862 RID: 141410
		private readonly Dictionary<int, AlterMarksView.WaitOperationUnit> WaitOperationMarks = new Dictionary<int, AlterMarksView.WaitOperationUnit>();

		// Token: 0x04022863 RID: 141411
		private bool IsCountdown;

		// Token: 0x04022864 RID: 141412
		private long EndTimeStamp;

		// Token: 0x04022865 RID: 141413
		private double CountdownTime;

		// Token: 0x04022866 RID: 141414
		private double CurTimeStamp;

		// Token: 0x04022867 RID: 141415
		[Nullable(2)]
		private UUIItem MaskItem;

		// Token: 0x04022868 RID: 141416
		[Nullable(2)]
		private AlterTime TimeItem;

		// Token: 0x04022869 RID: 141417
		[Nullable(2)]
		private ITagTask ListenTagTask;

		// Token: 0x0402286A RID: 141418
		[Nullable(2)]
		private EntityHandle CurPlayerEntity;

		// Token: 0x0402286B RID: 141419
		private bool IsBindMarkEvent;

		// Token: 0x0200BF82 RID: 49026
		[NullableContext(0)]
		private enum EOperationType
		{
			// Token: 0x0403AF2A RID: 241450
			Add,
			// Token: 0x0403AF2B RID: 241451
			Delete
		}

		// Token: 0x0200BF83 RID: 49027
		[NullableContext(2)]
		[Nullable(0)]
		private class WaitOperationUnit
		{
			// Token: 0x0403AF2C RID: 241452
			public AlterMarksView.EOperationType Type;

			// Token: 0x0403AF2D RID: 241453
			public global::Vector OriginPosition;

			// Token: 0x0403AF2E RID: 241454
			public AActor TrackActor;
		}
	}
}

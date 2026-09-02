using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006096 RID: 24726
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneItemDurabilityStatePanel : BattleChildViewPanel
	{
		// Token: 0x0603E667 RID: 255591 RVA: 0x00FF07B0 File Offset: 0x00FEE9B0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E668 RID: 255592 RVA: 0x00FF08C0 File Offset: 0x00FEEAC0
		public override void InitializeTemp()
		{
			this.HitLargePercent = (float)ConfigCommonParamById.GetIntConfig("HitLargeBufferPercent").Value / 10000f;
			this.InitDurabilityParentWidth();
			this.InitDurabilityLightTween();
			this.InitTweenAnim(5);
			this.InitTweenAnim(6);
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.VisibleMachine = new VisibleAnimMachine();
			this.VisibleMachine.InitCallback(new Action<bool>(this.OnRealVisibleChanged), new Action<bool>(this.OnPlayVisibleAnim), new Action<bool>(this.OnStopVisibleAnim));
			this.VisibleMachine.InitVisible(false);
		}

		// Token: 0x0603E669 RID: 255593 RVA: 0x00FF0960 File Offset: 0x00FEEB60
		public override void Reset()
		{
			this.CandidateMap.Clear();
			this.CurrentEntityId = -1;
			this.StopBarLerpAnimation();
			this.StopDurabilityLight();
			VisibleAnimMachine visibleMachine = this.VisibleMachine;
			if (visibleMachine != null)
			{
				visibleMachine.Reset();
			}
			this.VisibleMachine = null;
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
			base.Reset();
		}

		// Token: 0x0603E66A RID: 255594 RVA: 0x00FF09C4 File Offset: 0x00FEEBC4
		protected override void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<EntityHandle, int, int>(EEventName.OnAnySceneItemDurabilityChange, new Action<EntityHandle, int, int>(this.OnAnySceneItemDurabilityChange));
			Singleton<EventSystem>.Instance.Add<string, string>(EEventName.TextLanguageChange, new Action<string, string>(this.OnLanguageChange));
			Singleton<EventSystem>.Instance.Add<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			Singleton<EventSystem>.Instance.Add<Entity>(EEventName.OnSceneItemDurabilityEmpty, new Action<Entity>(this.OnSceneItemDurabilityEmpty));
		}

		// Token: 0x0603E66B RID: 255595 RVA: 0x00FF0A44 File Offset: 0x00FEEC44
		protected override void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnAnySceneItemDurabilityChange, new Action<EntityHandle, int, int>(this.OnAnySceneItemDurabilityChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.TextLanguageChange, new Action<string, string>(this.OnLanguageChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSceneItemDurabilityEmpty, new Action<Entity>(this.OnSceneItemDurabilityEmpty));
		}

		// Token: 0x0603E66C RID: 255596 RVA: 0x00FF0AC1 File Offset: 0x00FEECC1
		[NullableContext(2)]
		public void OnEnableSceneItemDurabilityUI(int entityId, bool enable, int? durability, int? maxDurability, string tidName)
		{
			if (enable)
			{
				this.RegisterEntity(entityId, durability.Value, maxDurability.Value, tidName);
				return;
			}
			this.UnregisterEntity(entityId);
		}

		// Token: 0x0603E66D RID: 255597 RVA: 0x00FF0AE5 File Offset: 0x00FEECE5
		private void RegisterEntity(int entityId, int durability, int maxDurability, string tidName)
		{
			this.CandidateMap[entityId] = new SceneItemDurabilityStatePanel.SceneItemDurabilityStateInfo
			{
				Durability = durability,
				MaxDurability = maxDurability,
				TidName = tidName
			};
			if (this.CurrentEntityId == -1)
			{
				this.ActivateDurabilityView(entityId);
			}
		}

		// Token: 0x0603E66E RID: 255598 RVA: 0x00FF0B20 File Offset: 0x00FEED20
		private void UnregisterEntity(int entityId)
		{
			this.CandidateMap.Remove(entityId);
			if (entityId == this.CurrentEntityId)
			{
				if (this.CandidateMap.Count > 0)
				{
					Dictionary<int, SceneItemDurabilityStatePanel.SceneItemDurabilityStateInfo>.KeyCollection.Enumerator enumerator = this.CandidateMap.Keys.GetEnumerator();
					enumerator.MoveNext();
					int entityId2 = enumerator.Current;
					this.SwitchToEntity(entityId2);
					return;
				}
				this.DeactivateDurabilityView();
			}
		}

		// Token: 0x0603E66F RID: 255599 RVA: 0x00FF0B80 File Offset: 0x00FEED80
		private void OnAnySceneItemDurabilityChange(EntityHandle entityHandle, int newDurability, int _curDurability)
		{
			int id = entityHandle.Id;
			if (!this.CandidateMap.ContainsKey(id))
			{
				return;
			}
			this.CandidateMap[id].Durability = newDurability;
			if (id != this.CurrentEntityId)
			{
				this.SwitchToEntity(id);
				return;
			}
			this.UpdateDurabilityBar(newDurability);
		}

		// Token: 0x0603E670 RID: 255600 RVA: 0x00FF0BD0 File Offset: 0x00FEEDD0
		private void OnRemoveEntity(ERemoveEntityType _removeType, EntityHandle handle)
		{
			if (handle == null || !handle.Valid)
			{
				return;
			}
			int id = handle.Id;
			if (!this.CandidateMap.ContainsKey(id))
			{
				return;
			}
			this.UnregisterEntity(id);
		}

		// Token: 0x0603E671 RID: 255601 RVA: 0x00FF0C0C File Offset: 0x00FEEE0C
		private void OnSceneItemDurabilityEmpty(Entity entity)
		{
			int id = entity.Id;
			if (!this.CandidateMap.ContainsKey(id))
			{
				return;
			}
			this.UnregisterEntity(id);
		}

		// Token: 0x0603E672 RID: 255602 RVA: 0x00FF0C38 File Offset: 0x00FEEE38
		private void ActivateDurabilityView(int entityId)
		{
			SceneItemDurabilityStatePanel.SceneItemDurabilityStateInfo sceneItemDurabilityStateInfo;
			if (!this.CandidateMap.TryGetValue(entityId, out sceneItemDurabilityStateInfo))
			{
				return;
			}
			this.CurrentEntityId = entityId;
			this.MaxDurability = sceneItemDurabilityStateInfo.MaxDurability;
			this.CurrentPercent = ((sceneItemDurabilityStateInfo.MaxDurability > 0) ? ((float)sceneItemDurabilityStateInfo.Durability / (float)sceneItemDurabilityStateInfo.MaxDurability) : 0f);
			this.SetDurabilityBarPercent(this.CurrentPercent);
			this.StopBarLerpAnimation();
			this.RefreshName(sceneItemDurabilityStateInfo.TidName);
			base.ShowBattleChildViewPanel();
			this.VisibleMachine.SetVisible(true, 667f);
		}

		// Token: 0x0603E673 RID: 255603 RVA: 0x00FF0CC3 File Offset: 0x00FEEEC3
		private void DeactivateDurabilityView()
		{
			this.CurrentEntityId = -1;
			this.StopBarLerpAnimation();
			this.StopDurabilityLight();
			this.VisibleMachine.SetVisible(false, 167f);
		}

		// Token: 0x0603E674 RID: 255604 RVA: 0x00FF0CE9 File Offset: 0x00FEEEE9
		private void SwitchToEntity(int entityId)
		{
			this.StopBarLerpAnimation();
			this.StopDurabilityLight();
			this.ActivateDurabilityView(entityId);
		}

		// Token: 0x0603E675 RID: 255605 RVA: 0x00FF0D00 File Offset: 0x00FEEF00
		private void UpdateDurabilityBar(int newDurability)
		{
			float currentPercent = this.CurrentPercent;
			this.CurrentPercent = ((this.MaxDurability > 0) ? ((float)newDurability / (float)this.MaxDurability) : 0f);
			this.SetDurabilityBarPercent(this.CurrentPercent);
			if (this.CurrentPercent < currentPercent)
			{
				this.PlayBarAnimation(this.CurrentPercent, currentPercent);
			}
		}

		// Token: 0x0603E676 RID: 255606 RVA: 0x00FF0D56 File Offset: 0x00FEEF56
		private void SetDurabilityBarPercent(float percent)
		{
			UUISprite sprite = base.GetSprite(1);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount(percent);
		}

		// Token: 0x0603E677 RID: 255607 RVA: 0x00FF0D6C File Offset: 0x00FEEF6C
		private void PlayBarAnimation(float durabilityPercent, float oldPercent)
		{
			bool flag = this.DurabilityStateMachine.IsOriginState();
			this.DurabilityStateMachine.GetHit(durabilityPercent, oldPercent);
			if (flag && !this.DurabilityStateMachine.IsOriginState())
			{
				this.SetBarBufferPercent(oldPercent, oldPercent);
			}
			this.IsPlayingDurabilityBarAnim = true;
			if (oldPercent - durabilityPercent < this.HitLargePercent)
			{
				this.PlayTweenAnim(5);
				return;
			}
			this.PlayTweenAnim(6);
			this.PlayDurabilityLight();
		}

		// Token: 0x0603E678 RID: 255608 RVA: 0x00FF0DD0 File Offset: 0x00FEEFD0
		private void SetBarBufferPercent(float pctBuffer, float pctReal)
		{
			float num = this.DurabilityParentWidth * pctReal;
			float num2 = this.DurabilityParentWidth * pctBuffer;
			float num3 = num2 - num;
			float num4 = num2 - (this.DurabilityParentWidth + num3) / 2f;
			UUIItem item = base.GetItem(2);
			item.SetAnchorOffsetX(num4);
			item.SetWidth(num3);
			item.SetUIActive(true);
			base.GetSprite(3).SetAnchorOffsetX(-num4);
		}

		// Token: 0x0603E679 RID: 255609 RVA: 0x00FF0E2B File Offset: 0x00FEF02B
		private void StopBarLerpAnimation()
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.DurabilityStateMachine.Reset();
			this.IsPlayingDurabilityBarAnim = false;
		}

		// Token: 0x0603E67A RID: 255610 RVA: 0x00FF0E54 File Offset: 0x00FEF054
		private void InitDurabilityLightTween()
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				AActor owner = item.GetOwner();
				this.DurabilityLightTweenComponent = (((owner != null) ? owner.GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) : null) as ULGUIPlayTweenComponent);
			}
		}

		// Token: 0x0603E67B RID: 255611 RVA: 0x00FF0E94 File Offset: 0x00FEF094
		private void PlayDurabilityLight()
		{
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(true);
			ULGUIPlayTweenComponent durabilityLightTweenComponent = this.DurabilityLightTweenComponent;
			if (durabilityLightTweenComponent == null)
			{
				return;
			}
			durabilityLightTweenComponent.Play();
		}

		// Token: 0x0603E67C RID: 255612 RVA: 0x00FF0EC4 File Offset: 0x00FEF0C4
		private void StopDurabilityLight()
		{
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
			ULGUIPlayTweenComponent durabilityLightTweenComponent = this.DurabilityLightTweenComponent;
			if (durabilityLightTweenComponent == null)
			{
				return;
			}
			durabilityLightTweenComponent.Stop();
		}

		// Token: 0x0603E67D RID: 255613 RVA: 0x00FF0EF4 File Offset: 0x00FEF0F4
		private void InitDurabilityParentWidth()
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				UUIItem parentAsUIItem = item.GetParentAsUIItem();
				if (parentAsUIItem != null)
				{
					this.DurabilityParentWidth = parentAsUIItem.GetWidth();
				}
			}
		}

		// Token: 0x0603E67E RID: 255614 RVA: 0x00FF0F22 File Offset: 0x00FEF122
		private void OnRealVisibleChanged(bool visible)
		{
			if (!visible)
			{
				base.HideBattleChildViewPanel();
			}
		}

		// Token: 0x0603E67F RID: 255615 RVA: 0x00FF0F30 File Offset: 0x00FEF130
		private void OnPlayVisibleAnim(bool visible)
		{
			if (visible)
			{
				this.SequencePlayer.PlaySequencePurely("ShowView", false, false, null, null, false);
				return;
			}
			this.SequencePlayer.PlaySequencePurely("CloseView", false, false, null, null, false);
		}

		// Token: 0x0603E680 RID: 255616 RVA: 0x00FF0F7B File Offset: 0x00FEF17B
		private void OnStopVisibleAnim(bool _visible)
		{
			this.SequencePlayer.StopCurrentSequence(false, false);
		}

		// Token: 0x0603E681 RID: 255617 RVA: 0x00FF0F8C File Offset: 0x00FEF18C
		private void RefreshName(string tidName)
		{
			UUIText text = base.GetText(0);
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(tidName);
			if (text != null)
			{
				text.SetText(configTextByKey, true);
			}
		}

		// Token: 0x0603E682 RID: 255618 RVA: 0x00FF0FB8 File Offset: 0x00FEF1B8
		private void OnLanguageChange(string _oldLang, string _newLang)
		{
			if (this.CurrentEntityId == -1)
			{
				return;
			}
			SceneItemDurabilityStatePanel.SceneItemDurabilityStateInfo sceneItemDurabilityStateInfo;
			if (this.CandidateMap.TryGetValue(this.CurrentEntityId, out sceneItemDurabilityStateInfo))
			{
				this.RefreshName(sceneItemDurabilityStateInfo.TidName);
			}
		}

		// Token: 0x0603E683 RID: 255619 RVA: 0x00FF0FF0 File Offset: 0x00FEF1F0
		private void InitTweenAnim(int componentType)
		{
			TArray<UActorComponent> tarray = base.GetItem(componentType).GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
			List<ULGUIPlayTweenComponent> list = new List<ULGUIPlayTweenComponent>(tarray.Count);
			foreach (UActorComponent uactorComponent in tarray)
			{
				list.Add((ULGUIPlayTweenComponent)uactorComponent);
			}
			this.TweenAnimMap[componentType] = list;
		}

		// Token: 0x0603E684 RID: 255620 RVA: 0x00FF1070 File Offset: 0x00FEF270
		private void PlayTweenAnim(int componentType)
		{
			List<ULGUIPlayTweenComponent> list;
			if (this.TweenAnimMap.TryGetValue(componentType, out list))
			{
				foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in list)
				{
					ulguiplayTweenComponent.Play();
				}
			}
		}

		// Token: 0x0603E685 RID: 255621 RVA: 0x00FF10CC File Offset: 0x00FEF2CC
		public override void OnTickBattleChildViewPanel(float delta)
		{
			if (this.CurrentEntityId == -1)
			{
				return;
			}
			if (this.IsPlayingDurabilityBarAnim)
			{
				float num = this.DurabilityStateMachine.UpdatePercent(delta);
				if (num < 0f)
				{
					this.StopBarLerpAnimation();
					return;
				}
				if (num <= 1f)
				{
					this.SetBarBufferPercent(num, this.CurrentPercent);
				}
			}
		}

		// Token: 0x04022F88 RID: 143240
		private const int SHOW_VIEW_ANIM_TIME = 667;

		// Token: 0x04022F89 RID: 143241
		private const int CLOSE_VIEW_ANIM_TIME = 167;

		// Token: 0x04022F8A RID: 143242
		private readonly Dictionary<int, SceneItemDurabilityStatePanel.SceneItemDurabilityStateInfo> CandidateMap = new Dictionary<int, SceneItemDurabilityStatePanel.SceneItemDurabilityStateInfo>();

		// Token: 0x04022F8B RID: 143243
		private int CurrentEntityId = -1;

		// Token: 0x04022F8C RID: 143244
		private readonly HpBufferStateMachine DurabilityStateMachine = new HpBufferStateMachine();

		// Token: 0x04022F8D RID: 143245
		private float CurrentPercent = 1f;

		// Token: 0x04022F8E RID: 143246
		private int MaxDurability;

		// Token: 0x04022F8F RID: 143247
		private float DurabilityParentWidth;

		// Token: 0x04022F90 RID: 143248
		private bool IsPlayingDurabilityBarAnim;

		// Token: 0x04022F91 RID: 143249
		private float HitLargePercent;

		// Token: 0x04022F92 RID: 143250
		[Nullable(2)]
		private ULGUIPlayTweenComponent DurabilityLightTweenComponent;

		// Token: 0x04022F93 RID: 143251
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x04022F94 RID: 143252
		[Nullable(2)]
		private VisibleAnimMachine VisibleMachine;

		// Token: 0x04022F95 RID: 143253
		private readonly Dictionary<int, List<ULGUIPlayTweenComponent>> TweenAnimMap = new Dictionary<int, List<ULGUIPlayTweenComponent>>();

		// Token: 0x0200C187 RID: 49543
		[NullableContext(0)]
		private enum EChildComponentType
		{
			// Token: 0x0403B989 RID: 244105
			NameText,
			// Token: 0x0403B98A RID: 244106
			BarSprite,
			// Token: 0x0403B98B RID: 244107
			BarBufferCanvas,
			// Token: 0x0403B98C RID: 244108
			BarBufferSprite,
			// Token: 0x0403B98D RID: 244109
			Light,
			// Token: 0x0403B98E RID: 244110
			AnimSmallHit,
			// Token: 0x0403B98F RID: 244111
			AnimBigHit
		}

		// Token: 0x0200C188 RID: 49544
		[NullableContext(0)]
		[RequiredMember]
		private class SceneItemDurabilityStateInfo
		{
			// Token: 0x0604E521 RID: 320801 RVA: 0x015B3C33 File Offset: 0x015B1E33
			[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
			[CompilerFeatureRequired("RequiredMembers")]
			public SceneItemDurabilityStateInfo()
			{
			}

			// Token: 0x0403B990 RID: 244112
			[RequiredMember]
			public int Durability;

			// Token: 0x0403B991 RID: 244113
			[RequiredMember]
			public int MaxDurability;

			// Token: 0x0403B992 RID: 244114
			[Nullable(1)]
			[RequiredMember]
			public string TidName;
		}
	}
}

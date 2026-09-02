using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060F5 RID: 24821
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarBase : UiPanelBase
	{
		// Token: 0x0603EB42 RID: 256834 RVA: 0x0100DAE4 File Offset: 0x0100BCE4
		public virtual UniTask InitByPathAsync(UUIItem parentItem, string prefabPath)
		{
			SpecialEnergyBarBase.<InitByPathAsync>d__21 <InitByPathAsync>d__;
			<InitByPathAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitByPathAsync>d__.<>4__this = this;
			<InitByPathAsync>d__.parentItem = parentItem;
			<InitByPathAsync>d__.prefabPath = prefabPath;
			<InitByPathAsync>d__.<>1__state = -1;
			<InitByPathAsync>d__.<>t__builder.Start<SpecialEnergyBarBase.<InitByPathAsync>d__21>(ref <InitByPathAsync>d__);
			return <InitByPathAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB43 RID: 256835 RVA: 0x0100DB38 File Offset: 0x0100BD38
		public UniTask InitByActorAsync(AActor actor)
		{
			SpecialEnergyBarBase.<InitByActorAsync>d__22 <InitByActorAsync>d__;
			<InitByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitByActorAsync>d__.<>4__this = this;
			<InitByActorAsync>d__.actor = actor;
			<InitByActorAsync>d__.<>1__state = -1;
			<InitByActorAsync>d__.<>t__builder.Start<SpecialEnergyBarBase.<InitByActorAsync>d__22>(ref <InitByActorAsync>d__);
			return <InitByActorAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB44 RID: 256836 RVA: 0x0100DB84 File Offset: 0x0100BD84
		public void InitData([Nullable(2)] BattleUiRoleData roleData, SpecialEnergyBarInfo config, bool needInitKeyItem = true)
		{
			this.NeedInitKeyItem = needInitKeyItem;
			if (this.Destroyed || roleData == null)
			{
				return;
			}
			if (this.RoleData != null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "能量条设置了多次角色的数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.ClearAllAttributeChangedCallback();
				this.ClearAllTagCountChangedCallback();
			}
			this.RoleData = roleData;
			this.Config = config;
			this.AttributeId = (EAttributeType)config.AttributeId;
			this.MaxAttributeId = (EAttributeType)config.MaxAttributeId;
			this.AttributeComponent = this.RoleData.AttributeComponent;
			this.TagComponent = this.RoleData.GameplayTagComponent;
			this.BuffComponent = this.RoleData.BuffComponent;
			this.OnInitData();
			this.PercentMachine.Init(this.GetTargetAttributePercent());
			this.InitKeyEnableTag();
		}

		// Token: 0x0603EB45 RID: 256837 RVA: 0x0100DC4A File Offset: 0x0100BE4A
		protected virtual void OnInitData()
		{
		}

		// Token: 0x0603EB46 RID: 256838 RVA: 0x0100DC4C File Offset: 0x0100BE4C
		protected virtual void AddEvents()
		{
			this.ListenForAttributeChanged(this.AttributeId, new Action<EAttributeType, float, float>(this.AttributeChanged));
			this.ListenForAttributeChanged(this.MaxAttributeId, new Action<EAttributeType, float, float>(this.MaxAttributeChanged));
		}

		// Token: 0x0603EB47 RID: 256839 RVA: 0x0100DC7E File Offset: 0x0100BE7E
		protected virtual void RemoveEvents()
		{
			this.RemoveListenAttributeChanged(this.AttributeId, new Action<EAttributeType, float, float>(this.AttributeChanged));
			this.RemoveListenAttributeChanged(this.MaxAttributeId, new Action<EAttributeType, float, float>(this.MaxAttributeChanged));
		}

		// Token: 0x0603EB48 RID: 256840 RVA: 0x0100DCB0 File Offset: 0x0100BEB0
		public void SetVisible(bool bVisible, int type = 0)
		{
			this.VisibleState = VisibleStateUtil.SetVisible(this.VisibleState, bVisible, type);
			this.RefreshVisible();
		}

		// Token: 0x0603EB49 RID: 256841 RVA: 0x0100DCCC File Offset: 0x0100BECC
		protected virtual void RefreshVisible()
		{
			if (base.InAsyncLoading() || base.IsRegister || base.IsCreateOrCreating)
			{
				return;
			}
			if (this.VisibleState == 0)
			{
				if (!base.IsShowOrShowing)
				{
					base.Show(null);
					return;
				}
			}
			else if (base.IsShowOrShowing)
			{
				base.Hide(null);
			}
		}

		// Token: 0x0603EB4A RID: 256842 RVA: 0x0100DD1C File Offset: 0x0100BF1C
		protected override bool DestroyOverride()
		{
			this.Destroyed = true;
			return false;
		}

		// Token: 0x0603EB4B RID: 256843 RVA: 0x0100DD28 File Offset: 0x0100BF28
		protected override void OnBeforeDestroy()
		{
			if (!base.InAsyncLoading())
			{
				this.RemoveEvents();
			}
			this.ClearAllTweenAnim();
			this.ClearAllAttributeChangedCallback();
			this.ClearAllTagCountChangedCallback();
			if (this.NeedInitKeyItem)
			{
				this.NeedInitKeyItem = false;
				SpecialEnergyBarKeyItem keyItem = this.KeyItem;
				if (keyItem != null)
				{
					keyItem.Destroy(null);
				}
				this.KeyItem = null;
			}
			foreach (SpecialEnergyBarKeyItem specialEnergyBarKeyItem in this.ExtraKeyItemList)
			{
				specialEnergyBarKeyItem.Destroy(null);
			}
			this.ExtraKeyItemList.Clear();
			if (this.NeedInitNumItem)
			{
				this.NeedInitNumItem = false;
				SpecialEnergyBarNumItem numItem = this.NumItem;
				if (numItem != null)
				{
					numItem.Destroy(null);
				}
				this.NumItem = null;
			}
			this.RoleData = null;
			this.AttributeComponent = null;
			this.TagComponent = null;
			this.BuffComponent = null;
		}

		// Token: 0x0603EB4C RID: 256844 RVA: 0x0100DE10 File Offset: 0x0100C010
		public int? GetEntityId()
		{
			BattleUiRoleData roleData = this.RoleData;
			if (roleData == null)
			{
				return null;
			}
			EntityHandle entityHandle = roleData.EntityHandle;
			if (entityHandle == null)
			{
				return null;
			}
			return new int?(entityHandle.Id);
		}

		// Token: 0x0603EB4D RID: 256845 RVA: 0x0100DE4E File Offset: 0x0100C04E
		public virtual void Tick(float delta)
		{
			if (this.PercentMachine.Update(delta))
			{
				this.OnBarPercentChanged();
			}
		}

		// Token: 0x0603EB4E RID: 256846 RVA: 0x0100DE64 File Offset: 0x0100C064
		private void AttributeChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.OnAttributeChanged();
		}

		// Token: 0x0603EB4F RID: 256847 RVA: 0x0100DE6C File Offset: 0x0100C06C
		private void MaxAttributeChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.OnMaxAttributeChanged();
		}

		// Token: 0x0603EB50 RID: 256848 RVA: 0x0100DE74 File Offset: 0x0100C074
		protected virtual void OnAttributeChanged()
		{
			this.PercentMachine.SetTargetPercent(this.GetTargetAttributePercent());
			this.OnBarPercentChanged();
		}

		// Token: 0x0603EB51 RID: 256849 RVA: 0x0100DE8D File Offset: 0x0100C08D
		protected virtual void OnMaxAttributeChanged()
		{
			this.PercentMachine.SetTargetPercent(this.GetTargetAttributePercent());
			this.OnBarPercentChanged();
		}

		// Token: 0x0603EB52 RID: 256850 RVA: 0x0100DEA6 File Offset: 0x0100C0A6
		protected virtual void OnBarPercentChanged()
		{
		}

		// Token: 0x0603EB53 RID: 256851 RVA: 0x0100DEA8 File Offset: 0x0100C0A8
		protected void ListenForAttributeChanged(EAttributeType attributeId, Action<EAttributeType, float, float> onAttributeChanged)
		{
			if (attributeId <= EAttributeType.None)
			{
				return;
			}
			BattleUiRoleData roleData = this.RoleData;
			BaseAttributeComponent baseAttributeComponent = (roleData != null) ? roleData.AttributeComponent : null;
			if (baseAttributeComponent == null)
			{
				return;
			}
			baseAttributeComponent.AddListener(attributeId, onAttributeChanged, null);
			this.AttributeChangedCallbackMap[attributeId] = onAttributeChanged;
		}

		// Token: 0x0603EB54 RID: 256852 RVA: 0x0100DEE8 File Offset: 0x0100C0E8
		protected void RemoveListenAttributeChanged(EAttributeType attributeId, Action<EAttributeType, float, float> onAttributeChanged)
		{
			if (attributeId <= EAttributeType.None)
			{
				return;
			}
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			if (attributeComponent == null)
			{
				return;
			}
			attributeComponent.RemoveListener(attributeId, onAttributeChanged);
			this.AttributeChangedCallbackMap.Remove(attributeId);
		}

		// Token: 0x0603EB55 RID: 256853 RVA: 0x0100DF1C File Offset: 0x0100C11C
		private void ClearAllAttributeChangedCallback()
		{
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			if (attributeComponent == null)
			{
				return;
			}
			foreach (KeyValuePair<EAttributeType, Action<EAttributeType, float, float>> keyValuePair in this.AttributeChangedCallbackMap)
			{
				EAttributeType eattributeType;
				Action<EAttributeType, float, float> action;
				keyValuePair.Deconstruct(out eattributeType, out action);
				EAttributeType attrId = eattributeType;
				Action<EAttributeType, float, float> callback = action;
				attributeComponent.RemoveListener(attrId, callback);
			}
			this.AttributeChangedCallbackMap.Clear();
		}

		// Token: 0x0603EB56 RID: 256854 RVA: 0x0100DF9C File Offset: 0x0100C19C
		protected void ListenForTagCountChanged(int tagId, BaseTagComponent.TTagChangedCallback onTagCountChange)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			ITagTask tagTask = (tagComponent != null) ? tagComponent.ListenForTagAnyCountChanged(tagId, onTagCountChange) : null;
			if (tagTask != null)
			{
				this.TagTaskList.Add(tagTask);
			}
		}

		// Token: 0x0603EB57 RID: 256855 RVA: 0x0100DFD0 File Offset: 0x0100C1D0
		protected void ClearAllTagCountChangedCallback()
		{
			foreach (ITagTask tagTask in this.TagTaskList)
			{
				tagTask.EndTask();
			}
			this.TagTaskList.Clear();
		}

		// Token: 0x0603EB58 RID: 256856 RVA: 0x0100E02C File Offset: 0x0100C22C
		protected void ListenForTagAddOrRemoveChanged(int tagId, BaseTagComponent.TTagSwitchedCallback onTagChange)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			ITagTask tagTask = (tagComponent != null) ? tagComponent.ListenForTagAddOrRemove(new int?(tagId), onTagChange, null) : null;
			if (tagTask != null)
			{
				this.TagTaskList.Add(tagTask);
			}
		}

		// Token: 0x0603EB59 RID: 256857 RVA: 0x0100E063 File Offset: 0x0100C263
		protected int GetBuffCountByBuffId(long buffId)
		{
			return this.BuffComponent.GetBuffTotalStackById(buffId, false);
		}

		// Token: 0x0603EB5A RID: 256858 RVA: 0x0100E074 File Offset: 0x0100C274
		protected UniTask LoadEffects()
		{
			SpecialEnergyBarBase.<LoadEffects>d__45 <LoadEffects>d__;
			<LoadEffects>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadEffects>d__.<>4__this = this;
			<LoadEffects>d__.<>1__state = -1;
			<LoadEffects>d__.<>t__builder.Start<SpecialEnergyBarBase.<LoadEffects>d__45>(ref <LoadEffects>d__);
			return <LoadEffects>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB5B RID: 256859 RVA: 0x0100E0B8 File Offset: 0x0100C2B8
		private UniTask LoadNiagara(string path, int index, [Nullable(new byte[]
		{
			1,
			2
		})] List<UNiagaraSystem> niagaraList)
		{
			SpecialEnergyBarBase.<LoadNiagara>d__46 <LoadNiagara>d__;
			<LoadNiagara>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadNiagara>d__.path = path;
			<LoadNiagara>d__.index = index;
			<LoadNiagara>d__.niagaraList = niagaraList;
			<LoadNiagara>d__.<>1__state = -1;
			<LoadNiagara>d__.<>t__builder.Start<SpecialEnergyBarBase.<LoadNiagara>d__46>(ref <LoadNiagara>d__);
			return <LoadNiagara>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB5C RID: 256860 RVA: 0x0100E10C File Offset: 0x0100C30C
		protected virtual UniTask InitKeyItem(UUIItem keyItemContainer)
		{
			SpecialEnergyBarBase.<InitKeyItem>d__47 <InitKeyItem>d__;
			<InitKeyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitKeyItem>d__.<>4__this = this;
			<InitKeyItem>d__.keyItemContainer = keyItemContainer;
			<InitKeyItem>d__.<>1__state = -1;
			<InitKeyItem>d__.<>t__builder.Start<SpecialEnergyBarBase.<InitKeyItem>d__47>(ref <InitKeyItem>d__);
			return <InitKeyItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB5D RID: 256861 RVA: 0x0100E158 File Offset: 0x0100C358
		protected UniTask InitNumItem(UUIItem keyItemContainer)
		{
			SpecialEnergyBarBase.<InitNumItem>d__48 <InitNumItem>d__;
			<InitNumItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitNumItem>d__.<>4__this = this;
			<InitNumItem>d__.keyItemContainer = keyItemContainer;
			<InitNumItem>d__.<>1__state = -1;
			<InitNumItem>d__.<>t__builder.Start<SpecialEnergyBarBase.<InitNumItem>d__48>(ref <InitNumItem>d__);
			return <InitNumItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB5E RID: 256862 RVA: 0x0100E1A4 File Offset: 0x0100C3A4
		protected void InitKeyEnableTag()
		{
			int keyEnableTagId = this.Config.KeyEnableTagId;
			if (keyEnableTagId != 0)
			{
				BaseTagComponent tagComponent = this.TagComponent;
				this.HasKeyEnableTag = (tagComponent != null && tagComponent.HasTag(keyEnableTagId));
				this.ListenForTagAddOrRemoveChanged(keyEnableTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnKeyEnableTagChanged));
			}
		}

		// Token: 0x0603EB5F RID: 256863 RVA: 0x0100E1EC File Offset: 0x0100C3EC
		protected float GetTargetAttributePercent()
		{
			if (this.AttributeComponent == null)
			{
				return 0f;
			}
			float currentValue = this.AttributeComponent.GetCurrentValue(this.AttributeId);
			float currentValue2 = this.AttributeComponent.GetCurrentValue(this.MaxAttributeId);
			float result = 0f;
			if (currentValue2 > 0f)
			{
				result = currentValue / currentValue2;
			}
			return result;
		}

		// Token: 0x0603EB60 RID: 256864 RVA: 0x0100E23E File Offset: 0x0100C43E
		protected virtual bool GetKeyEnable()
		{
			return this.PercentMachine.GetCurPercent() >= this.Config.DisableKeyOnPercent && (this.Config.KeyEnableTagId == 0 || this.HasKeyEnableTag);
		}

		// Token: 0x0603EB61 RID: 256865 RVA: 0x0100E272 File Offset: 0x0100C472
		protected void OnKeyEnableTagChanged(int tagId, bool tagExist)
		{
			this.HasKeyEnableTag = tagExist;
			this.OnKeyEnableChanged();
		}

		// Token: 0x0603EB62 RID: 256866 RVA: 0x0100E281 File Offset: 0x0100C481
		protected virtual void OnKeyEnableChanged()
		{
		}

		// Token: 0x0603EB63 RID: 256867 RVA: 0x0100E283 File Offset: 0x0100C483
		public virtual void OnChangeVisibleByTagChange(bool visible)
		{
		}

		// Token: 0x0603EB64 RID: 256868 RVA: 0x0100E285 File Offset: 0x0100C485
		public virtual void ReplaceFullEffect(UNiagaraSystem niagara)
		{
		}

		// Token: 0x0603EB65 RID: 256869 RVA: 0x0100E287 File Offset: 0x0100C487
		public virtual void RevertFullEffect()
		{
		}

		// Token: 0x0603EB66 RID: 256870 RVA: 0x0100E289 File Offset: 0x0100C489
		protected void InitTweenAnim(int componentType)
		{
			if (this.TweenAnimPlayer == null)
			{
				this.TweenAnimPlayer = new BattleUiTweenAnimPlayer();
			}
			this.TweenAnimPlayer.InitTweenAnim(componentType, base.GetItem(componentType), false);
		}

		// Token: 0x0603EB67 RID: 256871 RVA: 0x0100E2B2 File Offset: 0x0100C4B2
		protected void PlayTweenAnim(int componentType)
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer == null)
			{
				return;
			}
			tweenAnimPlayer.PlayTweenAnim(componentType);
		}

		// Token: 0x0603EB68 RID: 256872 RVA: 0x0100E2C5 File Offset: 0x0100C4C5
		protected void StopTweenAnim(int componentType)
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer == null)
			{
				return;
			}
			tweenAnimPlayer.StopTweenAnim(componentType);
		}

		// Token: 0x0603EB69 RID: 256873 RVA: 0x0100E2D8 File Offset: 0x0100C4D8
		protected virtual void ClearAllTweenAnim()
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer == null)
			{
				return;
			}
			tweenAnimPlayer.Clear(false);
		}

		// Token: 0x0603EB6A RID: 256874 RVA: 0x0100E2EB File Offset: 0x0100C4EB
		protected void SetTweenTimeScale(int componentType, float timeScale)
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer == null)
			{
				return;
			}
			tweenAnimPlayer.SetTweenTimeScale(componentType, timeScale);
		}

		// Token: 0x040232A6 RID: 144038
		protected bool Destroyed;

		// Token: 0x040232A7 RID: 144039
		protected string PrefabPath = string.Empty;

		// Token: 0x040232A8 RID: 144040
		[Nullable(2)]
		protected BattleUiRoleData RoleData;

		// Token: 0x040232A9 RID: 144041
		[Nullable(2)]
		protected SpecialEnergyBarInfo Config;

		// Token: 0x040232AA RID: 144042
		protected EAttributeType AttributeId;

		// Token: 0x040232AB RID: 144043
		protected EAttributeType MaxAttributeId;

		// Token: 0x040232AC RID: 144044
		[Nullable(2)]
		protected BaseAttributeComponent AttributeComponent;

		// Token: 0x040232AD RID: 144045
		[Nullable(2)]
		protected BaseTagComponent TagComponent;

		// Token: 0x040232AE RID: 144046
		[Nullable(2)]
		protected CharacterBuffComponent BuffComponent;

		// Token: 0x040232AF RID: 144047
		protected readonly List<ITagTask> TagTaskList = new List<ITagTask>();

		// Token: 0x040232B0 RID: 144048
		protected bool HasKeyEnableTag;

		// Token: 0x040232B1 RID: 144049
		[Nullable(new byte[]
		{
			1,
			2
		})]
		protected readonly List<UNiagaraSystem> NiagaraList = new List<UNiagaraSystem>();

		// Token: 0x040232B2 RID: 144050
		protected bool NeedInitKeyItem = true;

		// Token: 0x040232B3 RID: 144051
		[Nullable(2)]
		protected SpecialEnergyBarKeyItem KeyItem;

		// Token: 0x040232B4 RID: 144052
		protected readonly List<SpecialEnergyBarKeyItem> ExtraKeyItemList = new List<SpecialEnergyBarKeyItem>();

		// Token: 0x040232B5 RID: 144053
		protected bool NeedInitNumItem;

		// Token: 0x040232B6 RID: 144054
		[Nullable(2)]
		protected SpecialEnergyBarNumItem NumItem;

		// Token: 0x040232B7 RID: 144055
		protected readonly SpecialEnergyBarPercentMachine PercentMachine = new SpecialEnergyBarPercentMachine();

		// Token: 0x040232B8 RID: 144056
		[Nullable(2)]
		protected BattleUiTweenAnimPlayer TweenAnimPlayer;

		// Token: 0x040232B9 RID: 144057
		private readonly Dictionary<EAttributeType, Action<EAttributeType, float, float>> AttributeChangedCallbackMap = new Dictionary<EAttributeType, Action<EAttributeType, float, float>>();

		// Token: 0x040232BA RID: 144058
		protected int VisibleState;
	}
}

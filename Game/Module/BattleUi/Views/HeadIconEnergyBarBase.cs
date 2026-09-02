using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200601A RID: 24602
	[NullableContext(1)]
	[Nullable(0)]
	public class HeadIconEnergyBarBase : UiPanelBase
	{
		// Token: 0x0603DFE7 RID: 253927 RVA: 0x00FD1F00 File Offset: 0x00FD0100
		public void SetVisible(bool bVisible, int type = 0)
		{
			bool visible = this.GetVisible();
			this.VisibleState = VisibleStateUtil.SetVisible(this.VisibleState, bVisible, type);
			bool visible2 = this.GetVisible();
			if (visible == visible2 && base.GetActive() == visible2)
			{
				return;
			}
			this.SetActive(bVisible);
		}

		// Token: 0x0603DFE8 RID: 253928 RVA: 0x00FD1F41 File Offset: 0x00FD0141
		public bool GetVisible()
		{
			return VisibleStateUtil.GetVisible(this.VisibleState);
		}

		// Token: 0x0603DFE9 RID: 253929 RVA: 0x00FD1F50 File Offset: 0x00FD0150
		public void InitData(BattleUiRoleData roleData, HeadIconEnergyBar config)
		{
			this.RoleData = roleData;
			this.Config = new HeadIconEnergyBar?(config);
			this.PlayIncreaseEffect = config.PlayIncreaseEffect;
			this.AttributeComponent = this.RoleData.AttributeComponent;
			this.TagComponent = this.RoleData.GameplayTagComponent;
			this.AttributeId = (EAttributeType)config.AttributeId;
			this.MaxAttributeId = CharacterAttributeTypes.attributeIdsWithMax.GetValueOrDefault(this.AttributeId, EAttributeType.None);
		}

		// Token: 0x0603DFEA RID: 253930 RVA: 0x00FD1FC3 File Offset: 0x00FD01C3
		public void InitByPath(UUIItem parentItem, string prefabPath)
		{
			base.CreateByPathAsync(prefabPath, parentItem, false);
		}

		// Token: 0x0603DFEB RID: 253931 RVA: 0x00FD1FCF File Offset: 0x00FD01CF
		public void ChangeParent(UUIItem parentItem)
		{
			if (this.ParentUiItem == parentItem)
			{
				return;
			}
			this.ParentUiItem = parentItem;
			this.GetOriginalItem().SetUIParent(parentItem, true);
		}

		// Token: 0x0603DFEC RID: 253932 RVA: 0x00FD1FEF File Offset: 0x00FD01EF
		public virtual void Tick(float delta)
		{
			if (!base.IsShowOrShowing)
			{
				return;
			}
			if (this.PercentMachine.Update(delta))
			{
				this.OnBarPercentChanged();
			}
		}

		// Token: 0x0603DFED RID: 253933 RVA: 0x00FD200E File Offset: 0x00FD020E
		protected override void OnStart()
		{
			base.OnStart();
			this.PercentMachine.Init(this.GetTargetAttributePercent(), 0f, 400f, new Action<float, float>(this.TargetPercentChanged));
		}

		// Token: 0x0603DFEE RID: 253934 RVA: 0x00FD203D File Offset: 0x00FD023D
		protected override void OnBeforeShow()
		{
			this.AddEvents();
			if (this.GetTargetAttributePercent() != this.PercentMachine.GetTargetPercent())
			{
				this.PercentMachine.SetTargetPercent(this.GetTargetAttributePercent());
				this.OnBarPercentChanged();
			}
		}

		// Token: 0x0603DFEF RID: 253935 RVA: 0x00FD206F File Offset: 0x00FD026F
		protected void TargetPercentChanged(float newPercent, float oldPercent)
		{
			this.OnTargetPercentChanged();
		}

		// Token: 0x0603DFF0 RID: 253936 RVA: 0x00FD2077 File Offset: 0x00FD0277
		protected override void OnBeforeHide()
		{
			this.RemoveEvents();
		}

		// Token: 0x0603DFF1 RID: 253937 RVA: 0x00FD207F File Offset: 0x00FD027F
		protected override void OnBeforeDestroy()
		{
			this.ClearAllAttributeChangedCallback();
			this.ClearAllTagListeners();
			this.ClearAllTweenAnim();
		}

		// Token: 0x0603DFF2 RID: 253938 RVA: 0x00FD2093 File Offset: 0x00FD0293
		protected virtual void AddEvents()
		{
			this.ListenForAttributeChanged(this.AttributeId, new Action<EAttributeType, float, float>(this.AttributeChanged));
			this.ListenForAttributeChanged(this.MaxAttributeId, new Action<EAttributeType, float, float>(this.MaxAttributeChanged));
		}

		// Token: 0x0603DFF3 RID: 253939 RVA: 0x00FD20C5 File Offset: 0x00FD02C5
		protected virtual void RemoveEvents()
		{
			this.RemoveListenAttributeChanged(this.AttributeId, new Action<EAttributeType, float, float>(this.AttributeChanged));
			this.RemoveListenAttributeChanged(this.MaxAttributeId, new Action<EAttributeType, float, float>(this.MaxAttributeChanged));
		}

		// Token: 0x0603DFF4 RID: 253940 RVA: 0x00FD20F7 File Offset: 0x00FD02F7
		private void AttributeChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.OnAttributeChanged();
		}

		// Token: 0x0603DFF5 RID: 253941 RVA: 0x00FD20FF File Offset: 0x00FD02FF
		private void MaxAttributeChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.OnMaxAttributeChanged();
		}

		// Token: 0x0603DFF6 RID: 253942 RVA: 0x00FD2107 File Offset: 0x00FD0307
		protected virtual void OnAttributeChanged()
		{
			this.PercentMachine.SetTargetPercent(this.GetTargetAttributePercent());
			this.OnBarPercentChanged();
		}

		// Token: 0x0603DFF7 RID: 253943 RVA: 0x00FD2120 File Offset: 0x00FD0320
		protected virtual void OnMaxAttributeChanged()
		{
			this.PercentMachine.SetTargetPercent(this.GetTargetAttributePercent());
			this.OnBarPercentChanged();
		}

		// Token: 0x0603DFF8 RID: 253944 RVA: 0x00FD2139 File Offset: 0x00FD0339
		protected virtual void OnTargetPercentChanged()
		{
		}

		// Token: 0x0603DFF9 RID: 253945 RVA: 0x00FD213B File Offset: 0x00FD033B
		protected virtual void OnBarPercentChanged()
		{
		}

		// Token: 0x0603DFFA RID: 253946 RVA: 0x00FD2140 File Offset: 0x00FD0340
		protected float GetTargetAttributePercent()
		{
			double num = (double)this.AttributeComponent.GetCurrentValue(this.AttributeId);
			double num2 = (double)this.AttributeComponent.GetCurrentValue(this.MaxAttributeId);
			float result = 0f;
			if (num2 > 0.0)
			{
				result = (float)(num / num2);
			}
			return result;
		}

		// Token: 0x0603DFFB RID: 253947 RVA: 0x00FD218C File Offset: 0x00FD038C
		protected void ListenForAttributeChanged(EAttributeType attributeId, Action<EAttributeType, float, float> onAttributeChanged)
		{
			BattleUiRoleData roleData = this.RoleData;
			BaseAttributeComponent baseAttributeComponent = (roleData != null) ? roleData.AttributeComponent : null;
			if (baseAttributeComponent == null)
			{
				return;
			}
			baseAttributeComponent.AddListener(attributeId, onAttributeChanged, null);
			this.AttributeChangedCallbackMap[attributeId] = onAttributeChanged;
		}

		// Token: 0x0603DFFC RID: 253948 RVA: 0x00FD21C8 File Offset: 0x00FD03C8
		protected void RemoveListenAttributeChanged(EAttributeType attributeId, Action<EAttributeType, float, float> onAttributeChanged)
		{
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			if (attributeComponent == null)
			{
				return;
			}
			attributeComponent.RemoveListener(attributeId, onAttributeChanged);
			this.AttributeChangedCallbackMap.Remove(attributeId);
		}

		// Token: 0x0603DFFD RID: 253949 RVA: 0x00FD21F8 File Offset: 0x00FD03F8
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

		// Token: 0x0603DFFE RID: 253950 RVA: 0x00FD2278 File Offset: 0x00FD0478
		protected void ListenForTagAddOrRemoveChanged(int tagId, BaseTagComponent.TTagSwitchedCallback onTagChange)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent == null)
			{
				return;
			}
			ITagTask value = tagComponent.ListenForTagAddOrRemove(new int?(tagId), onTagChange, null);
			if (this.TagTaskMap == null)
			{
				this.TagTaskMap = new Dictionary<int, ITagTask>();
			}
			this.TagTaskMap[tagId] = value;
		}

		// Token: 0x0603DFFF RID: 253951 RVA: 0x00FD22C0 File Offset: 0x00FD04C0
		protected void RemoveListenTagAddOrRemove(int tagId)
		{
			Dictionary<int, ITagTask> tagTaskMap = this.TagTaskMap;
			ITagTask tagTask;
			if (tagTaskMap != null && tagTaskMap.Remove(tagId, out tagTask))
			{
				tagTask.EndTask();
			}
		}

		// Token: 0x0603E000 RID: 253952 RVA: 0x00FD22EC File Offset: 0x00FD04EC
		protected void ListenForTagCountChanged(int tagId, BaseTagComponent.TTagChangedCallback onTagCountChange)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent == null)
			{
				return;
			}
			ITagTask value = tagComponent.ListenForTagAnyCountChanged(tagId, onTagCountChange);
			if (this.TagCountTaskMap == null)
			{
				this.TagCountTaskMap = new Dictionary<int, ITagTask>();
			}
			this.TagCountTaskMap[tagId] = value;
		}

		// Token: 0x0603E001 RID: 253953 RVA: 0x00FD2330 File Offset: 0x00FD0530
		protected void RemoveListenTagCountChanged(int tagId)
		{
			Dictionary<int, ITagTask> tagCountTaskMap = this.TagCountTaskMap;
			ITagTask tagTask;
			if (tagCountTaskMap != null && tagCountTaskMap.Remove(tagId, out tagTask))
			{
				tagTask.EndTask();
			}
		}

		// Token: 0x0603E002 RID: 253954 RVA: 0x00FD235C File Offset: 0x00FD055C
		private void ClearAllTagListeners()
		{
			if (this.TagTaskMap != null)
			{
				foreach (ITagTask tagTask in this.TagTaskMap.Values)
				{
					tagTask.EndTask();
				}
				this.TagTaskMap.Clear();
			}
			if (this.TagCountTaskMap != null)
			{
				foreach (ITagTask tagTask2 in this.TagCountTaskMap.Values)
				{
					tagTask2.EndTask();
				}
				this.TagCountTaskMap.Clear();
			}
		}

		// Token: 0x0603E003 RID: 253955 RVA: 0x00FD241C File Offset: 0x00FD061C
		protected void InitTweenAnim(int componentType)
		{
			if (this.TweenAnimPlayer == null)
			{
				this.TweenAnimPlayer = new BattleUiTweenAnimPlayer();
			}
			this.TweenAnimPlayer.InitTweenAnim(componentType, base.GetItem(componentType), false);
		}

		// Token: 0x0603E004 RID: 253956 RVA: 0x00FD2445 File Offset: 0x00FD0645
		protected void PlayTweenAnim(int componentType)
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer == null)
			{
				return;
			}
			tweenAnimPlayer.PlayTweenAnim(componentType);
		}

		// Token: 0x0603E005 RID: 253957 RVA: 0x00FD2458 File Offset: 0x00FD0658
		protected void StopTweenAnim(int componentType)
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer == null)
			{
				return;
			}
			tweenAnimPlayer.StopTweenAnim(componentType);
		}

		// Token: 0x0603E006 RID: 253958 RVA: 0x00FD246B File Offset: 0x00FD066B
		protected void ClearAllTweenAnim()
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer == null)
			{
				return;
			}
			tweenAnimPlayer.Clear(false);
		}

		// Token: 0x04022C3C RID: 142396
		[Nullable(2)]
		public BattleUiRoleData RoleData;

		// Token: 0x04022C3D RID: 142397
		protected HeadIconEnergyBar? Config;

		// Token: 0x04022C3E RID: 142398
		protected bool PlayIncreaseEffect;

		// Token: 0x04022C3F RID: 142399
		protected int VisibleState;

		// Token: 0x04022C40 RID: 142400
		protected HeadIconEnergyBarPercentMachine PercentMachine = new HeadIconEnergyBarPercentMachine();

		// Token: 0x04022C41 RID: 142401
		protected EAttributeType AttributeId;

		// Token: 0x04022C42 RID: 142402
		protected EAttributeType MaxAttributeId;

		// Token: 0x04022C43 RID: 142403
		[Nullable(2)]
		protected BaseAttributeComponent AttributeComponent;

		// Token: 0x04022C44 RID: 142404
		[Nullable(2)]
		protected BaseTagComponent TagComponent;

		// Token: 0x04022C45 RID: 142405
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected Dictionary<int, ITagTask> TagTaskMap;

		// Token: 0x04022C46 RID: 142406
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected Dictionary<int, ITagTask> TagCountTaskMap;

		// Token: 0x04022C47 RID: 142407
		[Nullable(2)]
		protected BattleUiTweenAnimPlayer TweenAnimPlayer;

		// Token: 0x04022C48 RID: 142408
		private readonly Dictionary<EAttributeType, Action<EAttributeType, float, float>> AttributeChangedCallbackMap = new Dictionary<EAttributeType, Action<EAttributeType, float, float>>();
	}
}

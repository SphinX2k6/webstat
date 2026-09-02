using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.TabView.VisionSubView
{
	// Token: 0x0200506B RID: 20587
	[NullableContext(2)]
	[Nullable(0)]
	public abstract class RoleVisionCommonItem : UiPanelBase
	{
		// Token: 0x0603507B RID: 217211 RVA: 0x00D4D15A File Offset: 0x00D4B35A
		[NullableContext(1)]
		public RoleVisionCommonItem(UUIItem uiItem, EPhantomItemIndex index, [Nullable(2)] RoleDataBase roleData, bool needRedDot = false, bool needShowOccupyDetail = false, ERoleViewSource source = ERoleViewSource.Normal)
		{
			this.CurrentIndex = new EPhantomItemIndex?(index);
			this.SourceItem = uiItem;
			this.RoleData = roleData;
			this.NeedRedDot = needRedDot;
			this.NeedShowOccupyDetail = needShowOccupyDetail;
			this.Source = source;
		}

		// Token: 0x0603507C RID: 217212 RVA: 0x00D4D194 File Offset: 0x00D4B394
		public UniTask Init()
		{
			RoleVisionCommonItem.<Init>d__10 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<RoleVisionCommonItem.<Init>d__10>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603507D RID: 217213 RVA: 0x00D4D1D7 File Offset: 0x00D4B3D7
		public void OnDragItemDragBegin(int _)
		{
			this.OnDragBegin();
		}

		// Token: 0x0603507E RID: 217214 RVA: 0x00D4D1DF File Offset: 0x00D4B3DF
		public void OnDragItemDragEnd(int _)
		{
			this.OnDragEnd();
		}

		// Token: 0x0603507F RID: 217215 RVA: 0x00D4D1E7 File Offset: 0x00D4B3E7
		protected virtual void OnDragBegin()
		{
		}

		// Token: 0x06035080 RID: 217216 RVA: 0x00D4D1E9 File Offset: 0x00D4B3E9
		protected virtual void OnDragEnd()
		{
		}

		// Token: 0x06035081 RID: 217217 RVA: 0x00D4D1EB File Offset: 0x00D4B3EB
		public void SetShowType(int type)
		{
			this.ShowType = type;
		}

		// Token: 0x06035082 RID: 217218 RVA: 0x00D4D1F4 File Offset: 0x00D4B3F4
		public void ResetPosition()
		{
			this.OnResetPosition();
		}

		// Token: 0x06035083 RID: 217219 RVA: 0x00D4D1FC File Offset: 0x00D4B3FC
		protected virtual void OnResetPosition()
		{
		}

		// Token: 0x06035084 RID: 217220 RVA: 0x00D4D1FE File Offset: 0x00D4B3FE
		public void SetAnimationState(bool state)
		{
			this.AnimationState = state;
			this.OnChangeAnimationState();
		}

		// Token: 0x06035085 RID: 217221 RVA: 0x00D4D20D File Offset: 0x00D4B40D
		protected virtual void OnChangeAnimationState()
		{
		}

		// Token: 0x06035086 RID: 217222 RVA: 0x00D4D20F File Offset: 0x00D4B40F
		public int GetCurrentIndex()
		{
			return (int)this.CurrentIndex.Value;
		}

		// Token: 0x17008B6E RID: 35694
		// (get) Token: 0x06035087 RID: 217223 RVA: 0x00D4D21C File Offset: 0x00D4B41C
		[Nullable(1)]
		protected Action<EToggleState> OnClickVision
		{
			[NullableContext(1)]
			get
			{
				return delegate(EToggleState toggleState)
				{
				};
			}
		}

		// Token: 0x06035088 RID: 217224 RVA: 0x00D4D23D File Offset: 0x00D4B43D
		public PhantomDataBase GetCurrentData()
		{
			return this.CurrentData;
		}

		// Token: 0x06035089 RID: 217225 RVA: 0x00D4D245 File Offset: 0x00D4B445
		public virtual void SetAniLightState(bool state)
		{
		}

		// Token: 0x0603508A RID: 217226 RVA: 0x00D4D247 File Offset: 0x00D4B447
		public void UpdateItem(PhantomDataBase data, RoleDataBase roleData)
		{
			this.CurrentData = data;
			this.RoleData = (roleData ?? this.RoleData);
			this.RefreshPlusItem(data);
			this.RefreshIcon(data);
			this.RefreshQuality(data);
			this.OnUpdateItem(data);
		}

		// Token: 0x0603508B RID: 217227 RVA: 0x00D4D280 File Offset: 0x00D4B480
		private void RefreshIcon(PhantomDataBase data)
		{
			this.GetVisionTextureComponent().SetUIActive(data != null);
			if (data == null)
			{
				return;
			}
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(data.GetConfigId(true));
			base.SetTextureByPath(itemConfigData.IconMiddle, this.GetVisionTextureComponent(), new EUiViewName?(EUiViewName.VisionEquipmentView), null);
		}

		// Token: 0x0603508C RID: 217228 RVA: 0x00D4D2CF File Offset: 0x00D4B4CF
		private void RefreshQuality(PhantomDataBase data)
		{
			this.GetVisionQualitySprite().SetUIActive(data != null);
		}

		// Token: 0x0603508D RID: 217229 RVA: 0x00D4D2E0 File Offset: 0x00D4B4E0
		[NullableContext(1)]
		public void PlaySequence(string sequence)
		{
			this.OnPlaySequence(sequence);
		}

		// Token: 0x0603508E RID: 217230 RVA: 0x00D4D2E9 File Offset: 0x00D4B4E9
		[NullableContext(1)]
		protected virtual void OnPlaySequence(string sequence)
		{
		}

		// Token: 0x0603508F RID: 217231 RVA: 0x00D4D2EB File Offset: 0x00D4B4EB
		private void RefreshPlusItem(PhantomDataBase data)
		{
		}

		// Token: 0x06035090 RID: 217232 RVA: 0x00D4D2ED File Offset: 0x00D4B4ED
		public void SetSelected()
		{
			this.OnSelected();
		}

		// Token: 0x06035091 RID: 217233 RVA: 0x00D4D2F5 File Offset: 0x00D4B4F5
		protected virtual void OnSelected()
		{
		}

		// Token: 0x06035092 RID: 217234 RVA: 0x00D4D2F7 File Offset: 0x00D4B4F7
		public void SetUnSelected()
		{
			this.OnUnSelected();
		}

		// Token: 0x06035093 RID: 217235 RVA: 0x00D4D2FF File Offset: 0x00D4B4FF
		protected virtual void OnUnSelected()
		{
		}

		// Token: 0x06035094 RID: 217236 RVA: 0x00D4D301 File Offset: 0x00D4B501
		protected virtual void OnUpdateItem(PhantomDataBase data)
		{
		}

		// Token: 0x06035095 RID: 217237 RVA: 0x00D4D303 File Offset: 0x00D4B503
		public void OnUnOverlay(int _)
		{
			this.OnItemUnOverlay();
		}

		// Token: 0x06035096 RID: 217238 RVA: 0x00D4D30B File Offset: 0x00D4B50B
		protected virtual void OnItemUnOverlay()
		{
		}

		// Token: 0x06035097 RID: 217239 RVA: 0x00D4D30D File Offset: 0x00D4B50D
		public void OnOverlay(int _)
		{
			this.OnItemOverlay();
		}

		// Token: 0x06035098 RID: 217240 RVA: 0x00D4D315 File Offset: 0x00D4B515
		public void OnScrollToScrollView(int _)
		{
			this.OnScrollToScrollViewEvent();
		}

		// Token: 0x06035099 RID: 217241 RVA: 0x00D4D31D File Offset: 0x00D4B51D
		protected virtual void OnScrollToScrollViewEvent()
		{
		}

		// Token: 0x0603509A RID: 217242 RVA: 0x00D4D31F File Offset: 0x00D4B51F
		public void OnRemoveFromScrollView(int _)
		{
			this.OnRemoveFromScrollViewEvent();
		}

		// Token: 0x0603509B RID: 217243 RVA: 0x00D4D327 File Offset: 0x00D4B527
		protected virtual void OnRemoveFromScrollViewEvent()
		{
		}

		// Token: 0x0603509C RID: 217244 RVA: 0x00D4D329 File Offset: 0x00D4B529
		protected virtual void OnItemOverlay()
		{
		}

		// Token: 0x0603509D RID: 217245 RVA: 0x00D4D32B File Offset: 0x00D4B52B
		protected override void OnBeforeDestroy()
		{
			this.OnBeforeClearComponent();
		}

		// Token: 0x0603509E RID: 217246 RVA: 0x00D4D333 File Offset: 0x00D4B533
		public void SetToggleState(EToggleState state, bool fireEvent = false, bool ignoreAniState = false)
		{
			if (this.GetSelectToggle().ToggleState != state)
			{
				this.GetSelectToggle().SetToggleStateForce(state, fireEvent, ignoreAniState, false);
			}
		}

		// Token: 0x0603509F RID: 217247 RVA: 0x00D4D352 File Offset: 0x00D4B552
		protected virtual void OnBeforeClearComponent()
		{
		}

		// Token: 0x060350A0 RID: 217248
		protected abstract UUITexture GetVisionTextureComponent();

		// Token: 0x060350A1 RID: 217249
		protected abstract UUISprite GetVisionQualitySprite();

		// Token: 0x060350A2 RID: 217250
		protected abstract UUIItem GetVisionCostItem();

		// Token: 0x060350A3 RID: 217251
		protected abstract UUIText GetVisionCostText();

		// Token: 0x060350A4 RID: 217252
		public abstract UUIDraggableComponent GetDragComponent();

		// Token: 0x060350A5 RID: 217253
		protected abstract UUIExtendToggle GetSelectToggle();

		// Token: 0x060350A6 RID: 217254
		protected abstract UUIItem GetPlusItem();

		// Token: 0x0401E89F RID: 125087
		protected bool AnimationState;

		// Token: 0x0401E8A0 RID: 125088
		protected EPhantomItemIndex? CurrentIndex;

		// Token: 0x0401E8A1 RID: 125089
		protected PhantomDataBase CurrentData;

		// Token: 0x0401E8A2 RID: 125090
		protected RoleDataBase RoleData;

		// Token: 0x0401E8A3 RID: 125091
		protected int ShowType;

		// Token: 0x0401E8A4 RID: 125092
		private readonly UUIItem SourceItem;

		// Token: 0x0401E8A5 RID: 125093
		protected bool NeedRedDot;

		// Token: 0x0401E8A6 RID: 125094
		protected bool NeedShowOccupyDetail;

		// Token: 0x0401E8A7 RID: 125095
		protected ERoleViewSource Source;
	}
}

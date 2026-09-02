using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020024D6 RID: 9430
[NullableContext(2)]
[Nullable(0)]
public class PhantomInteractListItem : UiPanelBase
{
	// Token: 0x1700174E RID: 5966
	// (get) Token: 0x060124DD RID: 74973 RVA: 0x00508502 File Offset: 0x00506702
	public int ItemIndex
	{
		get
		{
			IPhantomInteractItemData itemData = this.ItemData;
			if (itemData == null)
			{
				return -1;
			}
			return itemData.ItemIndex;
		}
	}

	// Token: 0x060124DE RID: 74974 RVA: 0x00508518 File Offset: 0x00506718
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleStateChange))
		};
	}

	// Token: 0x060124DF RID: 74975 RVA: 0x005085D8 File Offset: 0x005067D8
	protected override UniTask OnBeforeStartAsync()
	{
		PhantomInteractListItem.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomInteractListItem.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060124E0 RID: 74976 RVA: 0x0050861B File Offset: 0x0050681B
	protected override void OnStart()
	{
		base.OnStart();
	}

	// Token: 0x060124E1 RID: 74977 RVA: 0x00508623 File Offset: 0x00506823
	public void DisableToggle()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_UnDetermined, false, false, false);
	}

	// Token: 0x060124E2 RID: 74978 RVA: 0x0050863C File Offset: 0x0050683C
	[NullableContext(1)]
	public UniTask Refresh(IPhantomInteractItemData itemData, bool showIndex, bool needAnim = true)
	{
		PhantomInteractListItem.<Refresh>d__17 <Refresh>d__;
		<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Refresh>d__.<>4__this = this;
		<Refresh>d__.itemData = itemData;
		<Refresh>d__.showIndex = showIndex;
		<Refresh>d__.needAnim = needAnim;
		<Refresh>d__.<>1__state = -1;
		<Refresh>d__.<>t__builder.Start<PhantomInteractListItem.<Refresh>d__17>(ref <Refresh>d__);
		return <Refresh>d__.<>t__builder.Task;
	}

	// Token: 0x060124E3 RID: 74979 RVA: 0x00508697 File Offset: 0x00506897
	public void SetSelected(bool isSelected)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060124E4 RID: 74980 RVA: 0x005086B4 File Offset: 0x005068B4
	private void OnToggleStateChange(EToggleState state)
	{
		bool flag = state == EToggleState.ETT_Checked;
		if (this.OnToggleStateChangeCb != null && this.ItemData != null)
		{
			this.OnToggleStateChangeCb(this, this.ItemData, flag);
		}
		if (!flag)
		{
			return;
		}
		if (this.OnClickCb != null && this.ItemData != null)
		{
			this.OnClickCb(this.ItemData);
		}
	}

	// Token: 0x060124E5 RID: 74981 RVA: 0x0050870E File Offset: 0x0050690E
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.Clear();
		}
		this.SeqPlayer = null;
	}

	// Token: 0x04008ECA RID: 36554
	private PhantomInteractListItemSlotIndexPanel SlotIndexPanel;

	// Token: 0x04008ECB RID: 36555
	private IPhantomInteractItemData ItemData;

	// Token: 0x04008ECC RID: 36556
	private PhantomInteractListItemSkillTagPanel SkillTagPanel;

	// Token: 0x04008ECD RID: 36557
	private int? CurrentMonsterId;

	// Token: 0x04008ECE RID: 36558
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x04008ECF RID: 36559
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<IPhantomInteractItemData> OnClickCb;

	// Token: 0x04008ED0 RID: 36560
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<IPhantomInteractItemData, bool> OnHoverCb;

	// Token: 0x04008ED1 RID: 36561
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<IPhantomInteractItemData> OnPointerDownCb;

	// Token: 0x04008ED2 RID: 36562
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<IPhantomInteractItemData> OnPointerUpCb;

	// Token: 0x04008ED3 RID: 36563
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<PhantomInteractListItem, IPhantomInteractItemData, bool> OnToggleStateChangeCb;

	// Token: 0x020087E1 RID: 34785
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DE85 RID: 188037
		TogItem,
		// Token: 0x0402DE86 RID: 188038
		TexIcon,
		// Token: 0x0402DE87 RID: 188039
		ItemTagRight,
		// Token: 0x0402DE88 RID: 188040
		ItemTagLeft,
		// Token: 0x0402DE89 RID: 188041
		ItemSpriteEmptyAdd,
		// Token: 0x0402DE8A RID: 188042
		ItemFXSelected
	}
}

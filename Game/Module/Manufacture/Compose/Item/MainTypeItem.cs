using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Compose.Item
{
	// Token: 0x020059DC RID: 23004
	[NullableContext(1)]
	[Nullable(0)]
	public class MainTypeItem : UiPanelBase, IGridProxy<EComposeListType>
	{
		// Token: 0x170094B6 RID: 38070
		// (get) Token: 0x0603A489 RID: 238729 RVA: 0x00EC75F7 File Offset: 0x00EC57F7
		// (set) Token: 0x0603A48A RID: 238730 RVA: 0x00EC75FF File Offset: 0x00EC57FF
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public IScrollViewDelegate<IGridProxy<EComposeListType>, EComposeListType> ScrollViewDelegate { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170094B7 RID: 38071
		// (get) Token: 0x0603A48B RID: 238731 RVA: 0x00EC7608 File Offset: 0x00EC5808
		// (set) Token: 0x0603A48C RID: 238732 RVA: 0x00EC7610 File Offset: 0x00EC5810
		public int GridIndex { get; set; }

		// Token: 0x170094B8 RID: 38072
		// (get) Token: 0x0603A48D RID: 238733 RVA: 0x00EC7619 File Offset: 0x00EC5819
		// (set) Token: 0x0603A48E RID: 238734 RVA: 0x00EC7621 File Offset: 0x00EC5821
		public int DisplayIndex { get; set; }

		// Token: 0x0603A48F RID: 238735 RVA: 0x00EC762C File Offset: 0x00EC582C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnItemButtonClicked));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A490 RID: 238736 RVA: 0x00EC76D4 File Offset: 0x00EC58D4
		public void Refresh(EComposeListType data, bool isSelected, int gridIndex)
		{
			this.MainType = data;
			string path = "";
			switch (this.MainType)
			{
			case EComposeListType.ReagentProduction:
				path = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ReagentProduction");
				break;
			case EComposeListType.Structure:
				path = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_Structure");
				break;
			case EComposeListType.Purification:
				path = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_Purification");
				break;
			}
			this.SetSpriteByPath(path, base.GetSprite(0), false, null, null);
		}

		// Token: 0x0603A491 RID: 238737 RVA: 0x00EC7758 File Offset: 0x00EC5958
		public void Clear()
		{
		}

		// Token: 0x0603A492 RID: 238738 RVA: 0x00EC775A File Offset: 0x00EC595A
		public void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
			Action<int> onClickedCallback = this.OnClickedCallback;
			if (onClickedCallback == null)
			{
				return;
			}
			onClickedCallback((int)this.MainType);
		}

		// Token: 0x0603A493 RID: 238739 RVA: 0x00EC7783 File Offset: 0x00EC5983
		public void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603A494 RID: 238740 RVA: 0x00EC7796 File Offset: 0x00EC5996
		public void CreateThenShowByActor(AActor actor)
		{
			base.CreateThenShowByActor(actor, null);
		}

		// Token: 0x0603A495 RID: 238741 RVA: 0x00EC77A0 File Offset: 0x00EC59A0
		public UniTask CreateThenShowByActorAsync(AActor actor)
		{
			MainTypeItem.<CreateThenShowByActorAsync>d__21 <CreateThenShowByActorAsync>d__;
			<CreateThenShowByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateThenShowByActorAsync>d__.<>4__this = this;
			<CreateThenShowByActorAsync>d__.actor = actor;
			<CreateThenShowByActorAsync>d__.<>1__state = -1;
			<CreateThenShowByActorAsync>d__.<>t__builder.Start<MainTypeItem.<CreateThenShowByActorAsync>d__21>(ref <CreateThenShowByActorAsync>d__);
			return <CreateThenShowByActorAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A496 RID: 238742 RVA: 0x00EC77EC File Offset: 0x00EC59EC
		public UniTask CreateByActorAsync(AActor actor)
		{
			MainTypeItem.<CreateByActorAsync>d__22 <CreateByActorAsync>d__;
			<CreateByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateByActorAsync>d__.<>4__this = this;
			<CreateByActorAsync>d__.actor = actor;
			<CreateByActorAsync>d__.<>1__state = -1;
			<CreateByActorAsync>d__.<>t__builder.Start<MainTypeItem.<CreateByActorAsync>d__22>(ref <CreateByActorAsync>d__);
			return <CreateByActorAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A497 RID: 238743 RVA: 0x00EC7837 File Offset: 0x00EC5A37
		public object GetKey(EComposeListType data, int gridIndex)
		{
			return this.MainType;
		}

		// Token: 0x0603A498 RID: 238744 RVA: 0x00EC7844 File Offset: 0x00EC5A44
		public EComposeListType GetMainType()
		{
			return this.MainType;
		}

		// Token: 0x0603A499 RID: 238745 RVA: 0x00EC784C File Offset: 0x00EC5A4C
		public void SetMainTypeCallback(Action<int> mainTypeCallback)
		{
			this.OnClickedCallback = mainTypeCallback;
		}

		// Token: 0x0603A49A RID: 238746 RVA: 0x00EC7855 File Offset: 0x00EC5A55
		public void SelectedItem()
		{
			if (this.OnClickedCallback != null)
			{
				this.OnClickedCallback((int)this.MainType);
			}
		}

		// Token: 0x0603A49B RID: 238747 RVA: 0x00EC7870 File Offset: 0x00EC5A70
		private void OnItemButtonClicked(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.ScrollViewDelegate.SelectGridProxy(this.GridIndex, this.DisplayIndex, true);
			}
		}

		// Token: 0x04021065 RID: 135269
		private EComposeListType MainType = EComposeListType.Purification;

		// Token: 0x04021066 RID: 135270
		[Nullable(2)]
		private Action<int> OnClickedCallback;

		// Token: 0x0200B9B2 RID: 47538
		[NullableContext(0)]
		public class EMainTypeDefine
		{
			// Token: 0x04039617 RID: 235031
			public const int IconSprite = 0;

			// Token: 0x04039618 RID: 235032
			public const int MainTypeExtendToggle = 1;
		}
	}
}

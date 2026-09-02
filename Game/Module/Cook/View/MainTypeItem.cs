using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E25 RID: 24101
	[NullableContext(1)]
	[Nullable(0)]
	public class MainTypeItem : UiPanelBase, IGridProxy<ECookListType>
	{
		// Token: 0x17009926 RID: 39206
		// (get) Token: 0x0603CA5D RID: 248413 RVA: 0x00F67347 File Offset: 0x00F65547
		// (set) Token: 0x0603CA5E RID: 248414 RVA: 0x00F6734F File Offset: 0x00F6554F
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public IScrollViewDelegate<IGridProxy<ECookListType>, ECookListType> ScrollViewDelegate { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009927 RID: 39207
		// (get) Token: 0x0603CA5F RID: 248415 RVA: 0x00F67358 File Offset: 0x00F65558
		// (set) Token: 0x0603CA60 RID: 248416 RVA: 0x00F67360 File Offset: 0x00F65560
		public int GridIndex { get; set; }

		// Token: 0x17009928 RID: 39208
		// (get) Token: 0x0603CA61 RID: 248417 RVA: 0x00F67369 File Offset: 0x00F65569
		// (set) Token: 0x0603CA62 RID: 248418 RVA: 0x00F67371 File Offset: 0x00F65571
		public int DisplayIndex { get; set; }

		// Token: 0x0603CA63 RID: 248419 RVA: 0x00F6737C File Offset: 0x00F6557C
		public void Refresh(ECookListType data, bool isSelected, int gridIndex)
		{
			this.MainType = new ECookListType?(data);
			ECookListType? mainType = this.MainType;
			ECookListType ecookListType = ECookListType.Cooking;
			string resourcePath;
			if (mainType.GetValueOrDefault() == ecookListType & mainType != null)
			{
				resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_Cooking");
			}
			else
			{
				resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_Machining");
			}
			this.SetSpriteByPath(resourcePath, base.GetSprite(0), false, null, null);
		}

		// Token: 0x0603CA64 RID: 248420 RVA: 0x00F673F3 File Offset: 0x00F655F3
		public void Clear()
		{
		}

		// Token: 0x0603CA65 RID: 248421 RVA: 0x00F673F5 File Offset: 0x00F655F5
		public void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
			Action<int> onClickedCallback = this.OnClickedCallback;
			if (onClickedCallback == null)
			{
				return;
			}
			onClickedCallback((int)this.MainType.Value);
		}

		// Token: 0x0603CA66 RID: 248422 RVA: 0x00F67423 File Offset: 0x00F65623
		public void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(1).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603CA67 RID: 248423 RVA: 0x00F67436 File Offset: 0x00F65636
		public void CreateThenShowByActor(AActor actor)
		{
			base.CreateThenShowByActor(actor, null);
		}

		// Token: 0x0603CA68 RID: 248424 RVA: 0x00F67440 File Offset: 0x00F65640
		public UniTask CreateThenShowByActorAsync(AActor actor)
		{
			MainTypeItem.<CreateThenShowByActorAsync>d__19 <CreateThenShowByActorAsync>d__;
			<CreateThenShowByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateThenShowByActorAsync>d__.<>4__this = this;
			<CreateThenShowByActorAsync>d__.actor = actor;
			<CreateThenShowByActorAsync>d__.<>1__state = -1;
			<CreateThenShowByActorAsync>d__.<>t__builder.Start<MainTypeItem.<CreateThenShowByActorAsync>d__19>(ref <CreateThenShowByActorAsync>d__);
			return <CreateThenShowByActorAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CA69 RID: 248425 RVA: 0x00F6748C File Offset: 0x00F6568C
		public UniTask CreateByActorAsync(AActor actor)
		{
			MainTypeItem.<CreateByActorAsync>d__20 <CreateByActorAsync>d__;
			<CreateByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateByActorAsync>d__.<>4__this = this;
			<CreateByActorAsync>d__.actor = actor;
			<CreateByActorAsync>d__.<>1__state = -1;
			<CreateByActorAsync>d__.<>t__builder.Start<MainTypeItem.<CreateByActorAsync>d__20>(ref <CreateByActorAsync>d__);
			return <CreateByActorAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CA6A RID: 248426 RVA: 0x00F674D7 File Offset: 0x00F656D7
		public object GetKey(ECookListType data, int gridIndex)
		{
			return gridIndex;
		}

		// Token: 0x0603CA6B RID: 248427 RVA: 0x00F674E0 File Offset: 0x00F656E0
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

		// Token: 0x0603CA6C RID: 248428 RVA: 0x00F67586 File Offset: 0x00F65786
		public ECookListType GetMainType()
		{
			return this.MainType.Value;
		}

		// Token: 0x0603CA6D RID: 248429 RVA: 0x00F67593 File Offset: 0x00F65793
		public void SetMainTypeCallback(Action<int> mainTypeCallback)
		{
			this.OnClickedCallback = mainTypeCallback;
		}

		// Token: 0x0603CA6E RID: 248430 RVA: 0x00F6759C File Offset: 0x00F6579C
		private void OnItemButtonClicked(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.ScrollViewDelegate.SelectGridProxy(this.GridIndex, this.DisplayIndex, true);
			}
		}

		// Token: 0x0402211A RID: 139546
		private ECookListType? MainType;

		// Token: 0x0402211B RID: 139547
		[Nullable(2)]
		private Action<int> OnClickedCallback;
	}
}

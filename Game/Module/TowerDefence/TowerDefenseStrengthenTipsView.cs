using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.GenericPrompt.View;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EDA RID: 20186
	public class TowerDefenseStrengthenTipsView : GenericPromptFloatTipsBase
	{
		// Token: 0x0603423C RID: 213564 RVA: 0x00D096A2 File Offset: 0x00D078A2
		[NullableContext(1)]
		public TowerDefenseStrengthenTipsView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603423D RID: 213565 RVA: 0x00D096AC File Offset: 0x00D078AC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603423E RID: 213566 RVA: 0x00D09718 File Offset: 0x00D07918
		protected override UniTask OnBeforeStartAsync()
		{
			TowerDefenseStrengthenTipsView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TowerDefenseStrengthenTipsView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603423F RID: 213567 RVA: 0x00D0975C File Offset: 0x00D0795C
		protected override UniTask OnPlayingStartSequenceAsync()
		{
			TowerDefenseStrengthenTipsView.<OnPlayingStartSequenceAsync>d__5 <OnPlayingStartSequenceAsync>d__;
			<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingStartSequenceAsync>d__.<>4__this = this;
			<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
			<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<TowerDefenseStrengthenTipsView.<OnPlayingStartSequenceAsync>d__5>(ref <OnPlayingStartSequenceAsync>d__);
			return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034240 RID: 213568 RVA: 0x00D097A0 File Offset: 0x00D079A0
		protected override UniTask OnPlayingCloseSequenceAsync()
		{
			TowerDefenseStrengthenTipsView.<OnPlayingCloseSequenceAsync>d__6 <OnPlayingCloseSequenceAsync>d__;
			<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
			<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
			<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<TowerDefenseStrengthenTipsView.<OnPlayingCloseSequenceAsync>d__6>(ref <OnPlayingCloseSequenceAsync>d__);
			return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034241 RID: 213569 RVA: 0x00D097E4 File Offset: 0x00D079E4
		private UniTask RefreshTips()
		{
			TowerDefenseStrengthenTipsView.<RefreshTips>d__7 <RefreshTips>d__;
			<RefreshTips>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshTips>d__.<>4__this = this;
			<RefreshTips>d__.<>1__state = -1;
			<RefreshTips>d__.<>t__builder.Start<TowerDefenseStrengthenTipsView.<RefreshTips>d__7>(ref <RefreshTips>d__);
			return <RefreshTips>d__.<>t__builder.Task;
		}

		// Token: 0x06034242 RID: 213570 RVA: 0x00D09827 File Offset: 0x00D07A27
		protected override void SetMainText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
		}

		// Token: 0x06034243 RID: 213571 RVA: 0x00D09829 File Offset: 0x00D07A29
		protected override void SetExtraText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
		}

		// Token: 0x0401E1BA RID: 123322
		[Nullable(2)]
		private TowerDefenseStrengthenTipsItem TipsItem;

		// Token: 0x0200AE86 RID: 44678
		private class EComponent
		{
			// Token: 0x04036307 RID: 221959
			public const int ItemVerticalLayout = 0;

			// Token: 0x04036308 RID: 221960
			public const int TipsItem = 1;
		}
	}
}

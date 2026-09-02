using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051A9 RID: 20905
	public class RoguelikeSkillOverView : UiViewBase
	{
		// Token: 0x06035C18 RID: 220184 RVA: 0x00D84C41 File Offset: 0x00D82E41
		[NullableContext(1)]
		public RoguelikeSkillOverView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06035C19 RID: 220185 RVA: 0x00D84C58 File Offset: 0x00D82E58
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035C1A RID: 220186 RVA: 0x00D84D24 File Offset: 0x00D82F24
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeSkillOverView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeSkillOverView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035C1B RID: 220187 RVA: 0x00D84D67 File Offset: 0x00D82F67
		protected override void OnBeforeDestroy()
		{
			this.SkillDescItemList = new List<RoguelikeSkillDesc>();
		}

		// Token: 0x06035C1C RID: 220188 RVA: 0x00D84D74 File Offset: 0x00D82F74
		protected UniTask InitDescItem()
		{
			RoguelikeSkillOverView.<InitDescItem>d__7 <InitDescItem>d__;
			<InitDescItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDescItem>d__.<>4__this = this;
			<InitDescItem>d__.<>1__state = -1;
			<InitDescItem>d__.<>t__builder.Start<RoguelikeSkillOverView.<InitDescItem>d__7>(ref <InitDescItem>d__);
			return <InitDescItem>d__.<>t__builder.Task;
		}

		// Token: 0x0401ED8D RID: 126349
		[Nullable(2)]
		public PopupCaptionItem CaptionItem;

		// Token: 0x0401ED8E RID: 126350
		[Nullable(1)]
		public List<RoguelikeSkillDesc> SkillDescItemList = new List<RoguelikeSkillDesc>();

		// Token: 0x0200B183 RID: 45443
		private class ERoguelikeSkillOverViewDefine
		{
			// Token: 0x040370CF RID: 225487
			public const int TxtSkillNum = 0;

			// Token: 0x040370D0 RID: 225488
			public const int CaptionItem = 1;

			// Token: 0x040370D1 RID: 225489
			public const int SkillDescItem = 2;

			// Token: 0x040370D2 RID: 225490
			public const int SkillDescContent = 3;

			// Token: 0x040370D3 RID: 225491
			public const int EmptyItem = 4;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005698 RID: 22168
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueResSkillOverView : UiViewBase
	{
		// Token: 0x0603873D RID: 231229 RVA: 0x00E4D1F2 File Offset: 0x00E4B3F2
		public RogueResSkillOverView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603873E RID: 231230 RVA: 0x00E4D208 File Offset: 0x00E4B408
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
		}

		// Token: 0x0603873F RID: 231231 RVA: 0x00E4D290 File Offset: 0x00E4B490
		protected override UniTask OnBeforeStartAsync()
		{
			RogueResSkillOverView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueResSkillOverView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038740 RID: 231232 RVA: 0x00E4D2D3 File Offset: 0x00E4B4D3
		protected override void OnBeforeDestroy()
		{
			this.SkillDescItemList.Clear();
		}

		// Token: 0x06038741 RID: 231233 RVA: 0x00E4D2E0 File Offset: 0x00E4B4E0
		protected UniTask InitDescItem()
		{
			RogueResSkillOverView.<InitDescItem>d__7 <InitDescItem>d__;
			<InitDescItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDescItem>d__.<>4__this = this;
			<InitDescItem>d__.<>1__state = -1;
			<InitDescItem>d__.<>t__builder.Start<RogueResSkillOverView.<InitDescItem>d__7>(ref <InitDescItem>d__);
			return <InitDescItem>d__.<>t__builder.Task;
		}

		// Token: 0x0402039E RID: 131998
		[Nullable(2)]
		public PopupCaptionItem CaptionItem;

		// Token: 0x0402039F RID: 131999
		public List<RogueResSkillDesc> SkillDescItemList = new List<RogueResSkillDesc>();

		// Token: 0x040203A0 RID: 132000
		private int SeasonId;
	}
}

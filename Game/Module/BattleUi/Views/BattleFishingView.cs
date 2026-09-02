using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FBA RID: 24506
	public class BattleFishingView : BattleVisibleChildView
	{
		// Token: 0x0603D9EA RID: 252394 RVA: 0x00FB2A74 File Offset: 0x00FB0C74
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D9EB RID: 252395 RVA: 0x00FB2B1F File Offset: 0x00FB0D1F
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			base.InitChildType(EBattleUiChild.TopButton);
		}

		// Token: 0x0603D9EC RID: 252396 RVA: 0x00FB2B30 File Offset: 0x00FB0D30
		[NullableContext(2)]
		protected override UniTask InitializeAsync(object param = null)
		{
			BattleFishingView.<InitializeAsync>d__5 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<BattleFishingView.<InitializeAsync>d__5>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D9ED RID: 252397 RVA: 0x00FB2B73 File Offset: 0x00FB0D73
		public override void Reset()
		{
			this.ButtonList.Clear();
			base.Reset();
		}

		// Token: 0x0603D9EE RID: 252398 RVA: 0x00FB2B88 File Offset: 0x00FB0D88
		[NullableContext(1)]
		private UniTask NewFishingButton(BattleFishingView.EChildType childType, string actionName)
		{
			BattleFishingView.<NewFishingButton>d__7 <NewFishingButton>d__;
			<NewFishingButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewFishingButton>d__.<>4__this = this;
			<NewFishingButton>d__.childType = childType;
			<NewFishingButton>d__.actionName = actionName;
			<NewFishingButton>d__.<>1__state = -1;
			<NewFishingButton>d__.<>t__builder.Start<BattleFishingView.<NewFishingButton>d__7>(ref <NewFishingButton>d__);
			return <NewFishingButton>d__.<>t__builder.Task;
		}

		// Token: 0x0603D9EF RID: 252399 RVA: 0x00FB2BDB File Offset: 0x00FB0DDB
		public void SetDriveFishingShipVisible(bool visible)
		{
			base.SetVisible(7, visible);
		}

		// Token: 0x0603D9F0 RID: 252400 RVA: 0x00FB2BE8 File Offset: 0x00FB0DE8
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length != 2)
			{
				return null;
			}
			int num;
			if (!int.TryParse(configParams[1], out num) || num < 0 || num >= this.BtnBindInfo.Count)
			{
				return null;
			}
			UUIButtonComponent button = base.GetButton(num);
			UUIItem uuiitem = (button != null) ? button.GetRootComponent() : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x0402296B RID: 141675
		[Nullable(1)]
		private readonly List<FishingButton> ButtonList = new List<FishingButton>();

		// Token: 0x0200C01C RID: 49180
		private enum EChildType
		{
			// Token: 0x0403B242 RID: 242242
			DockyardButton,
			// Token: 0x0403B243 RID: 242243
			QuestButton,
			// Token: 0x0403B244 RID: 242244
			TechButton,
			// Token: 0x0403B245 RID: 242245
			HandBookButton
		}

		// Token: 0x0200C01D RID: 49181
		private enum EVisibleReason
		{
			// Token: 0x0403B247 RID: 242247
			DriveFishingShip = 7
		}
	}
}

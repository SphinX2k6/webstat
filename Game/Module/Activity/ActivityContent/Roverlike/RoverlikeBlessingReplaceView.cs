using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063CF RID: 25551
	[NullableContext(2)]
	[Nullable(0)]
	public class RoverlikeBlessingReplaceView : RoverlikeActionViewBase
	{
		// Token: 0x0604026C RID: 262764 RVA: 0x0107097F File Offset: 0x0106EB7F
		[NullableContext(1)]
		public RoverlikeBlessingReplaceView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0604026D RID: 262765 RVA: 0x01070988 File Offset: 0x0106EB88
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnBtnReplaceClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnBtnKeepClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604026E RID: 262766 RVA: 0x01070AB4 File Offset: 0x0106ECB4
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeBlessingReplaceView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeBlessingReplaceView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604026F RID: 262767 RVA: 0x01070AF7 File Offset: 0x0106ECF7
		private void OnBtnReplaceClick()
		{
			base.TryInteractAction(delegate
			{
				IRoverlikeBlessingReplaceParam param = this.Param;
				if (param != null)
				{
					Action onConfirm = param.OnConfirm;
					if (onConfirm != null)
					{
						onConfirm();
					}
				}
				base.CloseMe(null);
			});
		}

		// Token: 0x06040270 RID: 262768 RVA: 0x01070B0C File Offset: 0x0106ED0C
		private void OnBtnKeepClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06040271 RID: 262769 RVA: 0x01070B18 File Offset: 0x0106ED18
		private void RefreshBlessingCards()
		{
			if (this.Param == null)
			{
				return;
			}
			bool flag = this.Param.Type == ERoverlikeBlessingReplaceType.Replace;
			IRoverlikeBlessingItemData data = new RoverlikeBlessingItemData
			{
				BlessId = this.Param.CurBlessId,
				AllowToggleInteract = new bool?(false)
			};
			IRoverlikeBlessingItemData data2 = new RoverlikeBlessingItemData
			{
				BlessId = this.Param.NewBlessId,
				AllowToggleInteract = new bool?(false),
				ShowRecommend = new bool?(!flag)
			};
			RoverlikeBlessingCardItem curBlessingItem = this.CurBlessingItem;
			if (curBlessingItem != null)
			{
				curBlessingItem.Refresh(data, false, 0);
			}
			RoverlikeBlessingCardItem newBlessingItem = this.NewBlessingItem;
			if (newBlessingItem == null)
			{
				return;
			}
			newBlessingItem.Refresh(data2, false, 1);
		}

		// Token: 0x06040272 RID: 262770 RVA: 0x01070BB9 File Offset: 0x0106EDB9
		protected override void OnBeforeShow()
		{
			RoverlikeBlessingCardItem curBlessingItem = this.CurBlessingItem;
			if (curBlessingItem != null)
			{
				curBlessingItem.RefreshDescMode();
			}
			RoverlikeBlessingCardItem newBlessingItem = this.NewBlessingItem;
			if (newBlessingItem == null)
			{
				return;
			}
			newBlessingItem.RefreshDescMode();
		}

		// Token: 0x06040273 RID: 262771 RVA: 0x01070BDC File Offset: 0x0106EDDC
		protected override void OnStart()
		{
			IRoverlikeBlessingReplaceParam roverlikeBlessingReplaceParam = this.OpenParam as IRoverlikeBlessingReplaceParam;
			if (roverlikeBlessingReplaceParam == null)
			{
				return;
			}
			this.Param = roverlikeBlessingReplaceParam;
			this.RefreshBlessingCards();
			string textStringId = (roverlikeBlessingReplaceParam.Type == ERoverlikeBlessingReplaceType.Enhance) ? "RoverRogue_BlessingUpgrade" : "RoverRogue_BlessingReplace";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), textStringId, Array.Empty<object>());
		}

		// Token: 0x06040274 RID: 262772 RVA: 0x01070C33 File Offset: 0x0106EE33
		protected override void OnBeforeDestroy()
		{
			this.Param = null;
		}

		// Token: 0x04023FEF RID: 147439
		protected RoverlikeBlessingCardItem CurBlessingItem;

		// Token: 0x04023FF0 RID: 147440
		protected RoverlikeBlessingCardItem NewBlessingItem;

		// Token: 0x04023FF1 RID: 147441
		private IRoverlikeBlessingReplaceParam Param;

		// Token: 0x0200C429 RID: 50217
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C644 RID: 247364
			public const int ItemCurBlessing = 0;

			// Token: 0x0403C645 RID: 247365
			public const int ItemNewBlessing = 1;

			// Token: 0x0403C646 RID: 247366
			public const int BtnKeep = 2;

			// Token: 0x0403C647 RID: 247367
			public const int BtnReplace = 3;

			// Token: 0x0403C648 RID: 247368
			public const int TxtTitle = 4;
		}
	}
}

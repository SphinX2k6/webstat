using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E2A RID: 20010
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseDifficultyChangePanel : UiPanelBase
	{
		// Token: 0x06033B9D RID: 211869 RVA: 0x00CEE120 File Offset: 0x00CEC320
		public UniTask Init(UUIItem item)
		{
			TrapDefenseDifficultyChangePanel.<Init>d__6 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<TrapDefenseDifficultyChangePanel.<Init>d__6>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06033B9E RID: 211870 RVA: 0x00CEE16B File Offset: 0x00CEC36B
		protected override void OnBeforeCreate()
		{
		}

		// Token: 0x06033B9F RID: 211871 RVA: 0x00CEE170 File Offset: 0x00CEC370
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtnLeft));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickBtnRight));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033BA0 RID: 211872 RVA: 0x00CEE2C0 File Offset: 0x00CEC4C0
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseDifficultyChangePanel.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseDifficultyChangePanel.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033BA1 RID: 211873 RVA: 0x00CEE303 File Offset: 0x00CEC503
		protected override void OnStart()
		{
		}

		// Token: 0x06033BA2 RID: 211874 RVA: 0x00CEE305 File Offset: 0x00CEC505
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x06033BA3 RID: 211875 RVA: 0x00CEE307 File Offset: 0x00CEC507
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x06033BA4 RID: 211876 RVA: 0x00CEE309 File Offset: 0x00CEC509
		public void OnClickBtnLeft()
		{
			this.ChangeDifficultyAdd(-1);
		}

		// Token: 0x06033BA5 RID: 211877 RVA: 0x00CEE312 File Offset: 0x00CEC512
		public void OnClickBtnRight()
		{
			this.ChangeDifficultyAdd(1);
		}

		// Token: 0x06033BA6 RID: 211878 RVA: 0x00CEE31B File Offset: 0x00CEC51B
		public void SetRedDotLeftVisible(bool visible)
		{
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(visible);
		}

		// Token: 0x06033BA7 RID: 211879 RVA: 0x00CEE32F File Offset: 0x00CEC52F
		public void SetRedDotRightVisible(bool visible)
		{
			UUIItem item = base.GetItem(5);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(visible);
		}

		// Token: 0x06033BA8 RID: 211880 RVA: 0x00CEE343 File Offset: 0x00CEC543
		public void UpdateDataList(ITrapDefenseDifficultyLevelInfo[] list, int selectIndex = 0)
		{
			this.DataList = list;
			this.SelectIndex = selectIndex;
			this.UpdateSelectData();
		}

		// Token: 0x06033BA9 RID: 211881 RVA: 0x00CEE35C File Offset: 0x00CEC55C
		private void UpdateSelectData()
		{
			ITrapDefenseDifficultyLevelInfo trapDefenseDifficultyLevelInfo = this.DataList[this.SelectIndex];
			base.GetText(1).ShowTextNew(trapDefenseDifficultyLevelInfo.NameKey.ToString());
			UUISprite sprite = base.GetSprite(0);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(trapDefenseDifficultyLevelInfo.NameBgKey);
			this.SetSpriteByPath(resourcePath, sprite, false, null, null);
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				Func<int, bool> onRedDotLeftVisibleCallback = this.OnRedDotLeftVisibleCallback;
				item.SetUIActive(onRedDotLeftVisibleCallback != null && onRedDotLeftVisibleCallback(this.GetAddAfterIndex(this.SelectIndex, -1)));
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				Func<int, bool> onRedDotRightVisibleCallback = this.OnRedDotRightVisibleCallback;
				item2.SetUIActive(onRedDotRightVisibleCallback != null && onRedDotRightVisibleCallback(this.GetAddAfterIndex(this.SelectIndex, 1)));
			}
			Action<ITrapDefenseDifficultyLevelInfo> onSelectDifficultyCallback = this.OnSelectDifficultyCallback;
			if (onSelectDifficultyCallback == null)
			{
				return;
			}
			onSelectDifficultyCallback(trapDefenseDifficultyLevelInfo);
		}

		// Token: 0x06033BAA RID: 211882 RVA: 0x00CEE42D File Offset: 0x00CEC62D
		public void ChangeDifficultyAdd(int add)
		{
			this.SelectIndex = this.GetAddAfterIndex(this.SelectIndex, add);
			this.UpdateSelectData();
			ModelBase<GuideModel>.Instance.FinishFocusGuideGroupOnView(EUiViewName.TrapDefenseMainLevelView);
		}

		// Token: 0x06033BAB RID: 211883 RVA: 0x00CEE457 File Offset: 0x00CEC657
		public int GetAddAfterIndex(int index, int add)
		{
			return (int)MathCommon.Warp((float)(index + add), 0f, (float)this.DataList.Length);
		}

		// Token: 0x0401DF29 RID: 122665
		public ITrapDefenseDifficultyLevelInfo[] DataList = new ITrapDefenseDifficultyLevelInfo[0];

		// Token: 0x0401DF2A RID: 122666
		public int SelectIndex;

		// Token: 0x0401DF2B RID: 122667
		[Nullable(2)]
		public Func<int, bool> OnRedDotLeftVisibleCallback;

		// Token: 0x0401DF2C RID: 122668
		[Nullable(2)]
		public Func<int, bool> OnRedDotRightVisibleCallback;

		// Token: 0x0401DF2D RID: 122669
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<ITrapDefenseDifficultyLevelInfo> OnSelectDifficultyCallback;

		// Token: 0x0200ADA0 RID: 44448
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04035EAE RID: 220846
			public const int SpriteBg = 0;

			// Token: 0x04035EAF RID: 220847
			public const int TextTitle = 1;

			// Token: 0x04035EB0 RID: 220848
			public const int BtnLeft = 2;

			// Token: 0x04035EB1 RID: 220849
			public const int ItemRedDotLeft = 3;

			// Token: 0x04035EB2 RID: 220850
			public const int BtnRight = 4;

			// Token: 0x04035EB3 RID: 220851
			public const int ItemRedDotRight = 5;
		}
	}
}

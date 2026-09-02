using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x0200650D RID: 25869
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RhythmShipSetItemBtn : SyncGridProxyAbstract<RhythmShipSetData>
	{
		// Token: 0x06040B9A RID: 265114 RVA: 0x01098FD8 File Offset: 0x010971D8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(7, typeof(UUIItem)));
			}
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtn))
			};
		}

		// Token: 0x06040B9B RID: 265115 RVA: 0x0109907C File Offset: 0x0109727C
		public override void Refresh(RhythmShipSetData data)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Text, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "RhythmShipSetItem_Btn", Array.Empty<object>());
			this.OnClickBtnCallBack = data.BtnCallBack;
		}

		// Token: 0x06040B9C RID: 265116 RVA: 0x010990CC File Offset: 0x010972CC
		private void OnClickBtn()
		{
			Action onClickBtnCallBack = this.OnClickBtnCallBack;
			if (onClickBtnCallBack == null)
			{
				return;
			}
			onClickBtnCallBack();
		}

		// Token: 0x06040B9D RID: 265117 RVA: 0x010990E0 File Offset: 0x010972E0
		public UUIItem GetBtnItem()
		{
			return base.GetButton(1).RootUIComp.Get();
		}

		// Token: 0x06040B9E RID: 265118 RVA: 0x01099101 File Offset: 0x01097301
		[NullableContext(2)]
		public UUIItem GetNavigationItem()
		{
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				return base.GetItem(7);
			}
			return null;
		}

		// Token: 0x0402449F RID: 148639
		[Nullable(2)]
		private Action OnClickBtnCallBack;
	}
}

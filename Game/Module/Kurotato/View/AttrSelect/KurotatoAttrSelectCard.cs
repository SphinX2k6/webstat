using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.AttrSelect
{
	// Token: 0x02005AC8 RID: 23240
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class KurotatoAttrSelectCard : GridProxyAbstract<IKurotatoAttrSelectCardData>
	{
		// Token: 0x0603AC29 RID: 240681 RVA: 0x00EE5F90 File Offset: 0x00EE4190
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickFunction));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AC2A RID: 240682 RVA: 0x00EE6038 File Offset: 0x00EE4238
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoAttrSelectCard.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoAttrSelectCard.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AC2B RID: 240683 RVA: 0x00EE607B File Offset: 0x00EE427B
		public void SetFunctionCb(Action<int> cb)
		{
			this.FunctionCb = cb;
		}

		// Token: 0x0603AC2C RID: 240684 RVA: 0x00EE6084 File Offset: 0x00EE4284
		public void SetAttrPreviewCb(Action<int, bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> cb)
		{
			this.AttrPreviewCb = cb;
		}

		// Token: 0x0603AC2D RID: 240685 RVA: 0x00EE608D File Offset: 0x00EE428D
		public void ClearAttrPreviewSelection()
		{
			this.CardItem.ClearAttrPreviewSelection();
		}

		// Token: 0x0603AC2E RID: 240686 RVA: 0x00EE609A File Offset: 0x00EE429A
		public int GetSelectionId()
		{
			IKurotatoAttrSelectCardData data = this.Data;
			if (data == null)
			{
				return 0;
			}
			return data.SelectionId;
		}

		// Token: 0x0603AC2F RID: 240687 RVA: 0x00EE60AD File Offset: 0x00EE42AD
		public bool IsRecommend()
		{
			IKurotatoAttrSelectCardData data = this.Data;
			return data != null && data.IsRecommend;
		}

		// Token: 0x0603AC30 RID: 240688 RVA: 0x00EE60C0 File Offset: 0x00EE42C0
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0 || configParams[0] != "UpgradeRecommend")
			{
				return null;
			}
			return this.CardItem.GetGuideUiItemAndUiItemForShowEx(configParams);
		}

		// Token: 0x0603AC31 RID: 240689 RVA: 0x00EE60E3 File Offset: 0x00EE42E3
		public override void Refresh(IKurotatoAttrSelectCardData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.CardItem.Refresh(data);
			base.GetButton(1).GetRootComponent().SetUIActive(data.SelectType == EKurotatoAttrSelectType.Upgrade);
		}

		// Token: 0x0603AC32 RID: 240690 RVA: 0x00EE6112 File Offset: 0x00EE4312
		private void OnClickFunction()
		{
			Action<int> functionCb = this.FunctionCb;
			if (functionCb == null)
			{
				return;
			}
			functionCb(this.Data.SelectionId);
		}

		// Token: 0x0603AC33 RID: 240691 RVA: 0x00EE612F File Offset: 0x00EE432F
		private void OnAttrPreview(bool active, IReadOnlyList<IKurotatoAttrPreviewDelta> deltas)
		{
			Action<int, bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> attrPreviewCb = this.AttrPreviewCb;
			if (attrPreviewCb == null)
			{
				return;
			}
			attrPreviewCb(this.Data.SelectionId, active, deltas);
		}

		// Token: 0x04021388 RID: 136072
		[Nullable(2)]
		private IKurotatoAttrSelectCardData Data;

		// Token: 0x04021389 RID: 136073
		private readonly KurotatoAttrSelectCardItem CardItem = new KurotatoAttrSelectCardItem();

		// Token: 0x0402138A RID: 136074
		[Nullable(2)]
		private Action<int> FunctionCb;

		// Token: 0x0402138B RID: 136075
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Action<int, bool, IReadOnlyList<IKurotatoAttrPreviewDelta>> AttrPreviewCb;

		// Token: 0x0200BAE4 RID: 47844
		[NullableContext(0)]
		private class EChildComp
		{
			// Token: 0x04039B01 RID: 236289
			public const int CardItem = 0;

			// Token: 0x04039B02 RID: 236290
			public const int ButtonFunction = 1;
		}
	}
}

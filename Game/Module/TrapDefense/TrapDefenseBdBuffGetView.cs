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
	// Token: 0x02004E59 RID: 20057
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBdBuffGetView : UiViewBase
	{
		// Token: 0x06033D3F RID: 212287 RVA: 0x00CF5DA2 File Offset: 0x00CF3FA2
		public TrapDefenseBdBuffGetView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06033D40 RID: 212288 RVA: 0x00CF5DAC File Offset: 0x00CF3FAC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnClose));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033D41 RID: 212289 RVA: 0x00CF5E74 File Offset: 0x00CF4074
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseBdBuffGetView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBdBuffGetView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033D42 RID: 212290 RVA: 0x00CF5EB7 File Offset: 0x00CF40B7
		protected override void OnStart()
		{
		}

		// Token: 0x06033D43 RID: 212291 RVA: 0x00CF5EB9 File Offset: 0x00CF40B9
		protected override void OnAddEventListener()
		{
		}

		// Token: 0x06033D44 RID: 212292 RVA: 0x00CF5EBB File Offset: 0x00CF40BB
		protected override void OnRemoveEventListener()
		{
		}

		// Token: 0x06033D45 RID: 212293 RVA: 0x00CF5EBD File Offset: 0x00CF40BD
		protected override void OnBeforeShow()
		{
			this.UpdateData();
		}

		// Token: 0x06033D46 RID: 212294 RVA: 0x00CF5EC5 File Offset: 0x00CF40C5
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x06033D47 RID: 212295 RVA: 0x00CF5EC7 File Offset: 0x00CF40C7
		private void OnClickBtnClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06033D48 RID: 212296 RVA: 0x00CF5ED0 File Offset: 0x00CF40D0
		public void UpdateData()
		{
			if (this.BdBuffData == null)
			{
				return;
			}
			this.PanelBdBuffDesc.SetActive(true);
			this.PanelBdBuffDesc.UpdateDataGetMode(this.BdBuffData);
			this.UpdateBdProgressItem();
		}

		// Token: 0x06033D49 RID: 212297 RVA: 0x00CF5F00 File Offset: 0x00CF4100
		private void UpdateBdProgressItem()
		{
			TrapDefenseBdData belongBdData = this.BdBuffData.GetBelongBdData();
			bool flag = !belongBdData.IsZeroBdType();
			this.BdProgressItem.SetActive(flag);
			if (flag)
			{
				if (ModelBase<TrapDefenseModel>.Instance.RougeModeData.IsCheckBdProgress)
				{
					this.BdProgressItem.RefreshCheckProgress(belongBdData);
					return;
				}
				this.BdProgressItem.RefreshItem(belongBdData);
			}
		}

		// Token: 0x06033D4A RID: 212298 RVA: 0x00CF5F5C File Offset: 0x00CF415C
		protected override void OnAfterPlayStartSequence()
		{
			this.CheckBdUpStageEffect().Forget();
		}

		// Token: 0x06033D4B RID: 212299 RVA: 0x00CF5F6C File Offset: 0x00CF416C
		public UniTask CheckBdUpStageEffect()
		{
			TrapDefenseBdBuffGetView.<CheckBdUpStageEffect>d__16 <CheckBdUpStageEffect>d__;
			<CheckBdUpStageEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckBdUpStageEffect>d__.<>4__this = this;
			<CheckBdUpStageEffect>d__.<>1__state = -1;
			<CheckBdUpStageEffect>d__.<>t__builder.Start<TrapDefenseBdBuffGetView.<CheckBdUpStageEffect>d__16>(ref <CheckBdUpStageEffect>d__);
			return <CheckBdUpStageEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06033D4C RID: 212300 RVA: 0x00CF5FAF File Offset: 0x00CF41AF
		protected override void OnAfterDestroy()
		{
		}

		// Token: 0x0401DFBA RID: 122810
		public TrapDefenseBdSumBuffDescPanel PanelBdBuffDesc;

		// Token: 0x0401DFBB RID: 122811
		public TrapDefenseBdBuffSelectBdItem BdProgressItem;

		// Token: 0x0401DFBC RID: 122812
		public TrapDefenseBdBuffData BdBuffData;

		// Token: 0x0200ADFC RID: 44540
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04036085 RID: 221317
			public const int BtnClose = 0;

			// Token: 0x04036086 RID: 221318
			public const int ItemBuffDesc = 1;

			// Token: 0x04036087 RID: 221319
			public const int ItemBdProgress = 2;
		}
	}
}

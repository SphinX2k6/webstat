using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060F2 RID: 24818
	public class SpecialEnergyBarZheZhiEffectItem : UiPanelBase
	{
		// Token: 0x0603EB2D RID: 256813 RVA: 0x0100D558 File Offset: 0x0100B758
		[NullableContext(1)]
		public UniTask InitAsync(UUIItem parentItem)
		{
			SpecialEnergyBarZheZhiEffectItem.<InitAsync>d__3 <InitAsync>d__;
			<InitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAsync>d__.<>4__this = this;
			<InitAsync>d__.parentItem = parentItem;
			<InitAsync>d__.<>1__state = -1;
			<InitAsync>d__.<>t__builder.Start<SpecialEnergyBarZheZhiEffectItem.<InitAsync>d__3>(ref <InitAsync>d__);
			return <InitAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB2E RID: 256814 RVA: 0x0100D5A4 File Offset: 0x0100B7A4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EB2F RID: 256815 RVA: 0x0100D6B2 File Offset: 0x0100B8B2
		protected override void OnStart()
		{
			base.OnStart();
			base.GetUiNiagara(3).SetUIActive(false);
			base.GetUiNiagara(4).SetUIActive(false);
			this.InitTweenAnim(5);
			this.InitTweenAnim(6);
		}

		// Token: 0x0603EB30 RID: 256816 RVA: 0x0100D6E2 File Offset: 0x0100B8E2
		[NullableContext(1)]
		public void SetNiagaraParam(string varName, float value)
		{
			base.GetUiNiagara(2).SetNiagaraVarFloat(varName, value);
		}

		// Token: 0x0603EB31 RID: 256817 RVA: 0x0100D6F4 File Offset: 0x0100B8F4
		public void SetVisible(bool value)
		{
			if (this.Visible == value)
			{
				return;
			}
			this.Visible = value;
			if (value)
			{
				this.StopTweenAnim(6);
				base.GetUiNiagara(4).SetUIActive(false);
				this.PlayTweenAnim(5);
				return;
			}
			this.StopTweenAnim(5);
			base.GetUiNiagara(3).SetUIActive(false);
			this.PlayTweenAnim(6);
		}

		// Token: 0x0603EB32 RID: 256818 RVA: 0x0100D74C File Offset: 0x0100B94C
		protected override void OnBeforeHide()
		{
			this.TweenAnimMap = null;
		}

		// Token: 0x0603EB33 RID: 256819 RVA: 0x0100D758 File Offset: 0x0100B958
		private void InitTweenAnim(int componentType)
		{
			TArray<UActorComponent> tarray = base.GetItem(componentType).GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
			int num = tarray.Num();
			ULGUIPlayTweenComponent[] array = new ULGUIPlayTweenComponent[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = (ULGUIPlayTweenComponent)tarray.Get(i);
			}
			if (this.TweenAnimMap == null)
			{
				this.TweenAnimMap = new Dictionary<int, ULGUIPlayTweenComponent[]>();
			}
			this.TweenAnimMap[componentType] = array;
		}

		// Token: 0x0603EB34 RID: 256820 RVA: 0x0100D7CC File Offset: 0x0100B9CC
		private void PlayTweenAnim(int componentType)
		{
			ULGUIPlayTweenComponent[] array;
			if (this.TweenAnimMap != null && this.TweenAnimMap.TryGetValue(componentType, out array))
			{
				ULGUIPlayTweenComponent[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].Play();
				}
			}
		}

		// Token: 0x0603EB35 RID: 256821 RVA: 0x0100D80C File Offset: 0x0100BA0C
		private void StopTweenAnim(int componentType)
		{
			ULGUIPlayTweenComponent[] array;
			if (this.TweenAnimMap != null && this.TweenAnimMap.TryGetValue(componentType, out array))
			{
				ULGUIPlayTweenComponent[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].Stop();
				}
			}
		}

		// Token: 0x0402329E RID: 144030
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<int, ULGUIPlayTweenComponent[]> TweenAnimMap;

		// Token: 0x0402329F RID: 144031
		private bool Visible;

		// Token: 0x0200C26E RID: 49774
		private enum EChildType
		{
			// Token: 0x0403BF12 RID: 245522
			EnergyItem,
			// Token: 0x0403BF13 RID: 245523
			IconItem,
			// Token: 0x0403BF14 RID: 245524
			EnergyEffect,
			// Token: 0x0403BF15 RID: 245525
			StartEffect,
			// Token: 0x0403BF16 RID: 245526
			CloseEffect,
			// Token: 0x0403BF17 RID: 245527
			AnimStart,
			// Token: 0x0403BF18 RID: 245528
			AnimClose
		}
	}
}

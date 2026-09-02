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
	// Token: 0x02005FC4 RID: 24516
	public class BattleSkillCombineItem : UiPanelBase
	{
		// Token: 0x0603DA58 RID: 252504 RVA: 0x00FB4A18 File Offset: 0x00FB2C18
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DA59 RID: 252505 RVA: 0x00FB4A60 File Offset: 0x00FB2C60
		protected override UniTask OnBeforeStartAsync()
		{
			BattleSkillCombineItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleSkillCombineItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DA5A RID: 252506 RVA: 0x00FB4AA3 File Offset: 0x00FB2CA3
		protected override void OnStart()
		{
		}

		// Token: 0x0603DA5B RID: 252507 RVA: 0x00FB4AA5 File Offset: 0x00FB2CA5
		public void SetVisible(bool bVisible)
		{
			if (bVisible)
			{
				if (!base.IsShowOrShowing)
				{
					base.Show(null);
					return;
				}
			}
			else if (base.IsShowOrShowing)
			{
				base.Hide(null);
			}
		}

		// Token: 0x0603DA5C RID: 252508 RVA: 0x00FB4AC9 File Offset: 0x00FB2CC9
		public void Refresh()
		{
			CommonKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshAction("组合主键");
		}

		// Token: 0x0402299B RID: 141723
		[Nullable(2)]
		private CommonKeyItem KeyItem;

		// Token: 0x0200C02D RID: 49197
		private enum EChildType
		{
			// Token: 0x0403B292 RID: 242322
			KeyItem
		}
	}
}

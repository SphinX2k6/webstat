using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.FirstPersonTurret.View
{
	// Token: 0x02005D84 RID: 23940
	public class FirstPersonTurretRoleHpPanel : UiPanelBase
	{
		// Token: 0x0603C46D RID: 246893 RVA: 0x00F4B340 File Offset: 0x00F49540
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C46E RID: 246894 RVA: 0x00F4B450 File Offset: 0x00F49650
		protected override UniTask OnBeforeStartAsync()
		{
			FirstPersonTurretRoleHpPanel.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FirstPersonTurretRoleHpPanel.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C46F RID: 246895 RVA: 0x00F4B494 File Offset: 0x00F49694
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(3);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			UUIItem item4 = base.GetItem(4);
			if (item4 != null)
			{
				item4.SetUIActive(false);
			}
			UUIItem item5 = base.GetItem(5);
			if (item5 != null)
			{
				item5.SetUIActive(false);
			}
			UUIItem item6 = base.GetItem(6);
			if (item6 == null)
			{
				return;
			}
			item6.SetUIActive(false);
		}

		// Token: 0x0603C470 RID: 246896 RVA: 0x00F4B512 File Offset: 0x00F49712
		public void Refresh(float hp, float hpMax)
		{
			FirstPersonTurretRoleHpItem hpItem = this.HpItem;
			if (hpItem == null)
			{
				return;
			}
			hpItem.Refresh(hp, hpMax);
		}

		// Token: 0x0603C471 RID: 246897 RVA: 0x00F4B526 File Offset: 0x00F49726
		public void Tick(float delta)
		{
			FirstPersonTurretRoleHpItem hpItem = this.HpItem;
			if (hpItem == null)
			{
				return;
			}
			hpItem.Tick(delta);
		}

		// Token: 0x04021E65 RID: 138853
		[Nullable(2)]
		private FirstPersonTurretRoleHpItem HpItem;
	}
}

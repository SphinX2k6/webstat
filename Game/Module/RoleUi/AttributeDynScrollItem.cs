using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi
{
	// Token: 0x02005057 RID: 20567
	[NullableContext(1)]
	[Nullable(0)]
	public class AttributeDynScrollItem : UiPanelBase, IDynamicScrollItem<IAttributeInfo>
	{
		// Token: 0x06034F36 RID: 216886 RVA: 0x00D47380 File Offset: 0x00D45580
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06034F37 RID: 216887 RVA: 0x00D473F0 File Offset: 0x00D455F0
		protected override void OnStart()
		{
			this.RoleAttributeItem = new RoleAttributeItem();
			this.RoleAttributeItem.CreateThenShowByActor(base.GetItem(0).GetOwner(), null);
		}

		// Token: 0x06034F38 RID: 216888 RVA: 0x00D47415 File Offset: 0x00D45615
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x06034F39 RID: 216889 RVA: 0x00D47417 File Offset: 0x00D45617
		[return: Nullable(2)]
		public AUIBaseActor GetUsingItem(IAttributeInfo data)
		{
			return base.GetRootItem().GetOwner() as AUIBaseActor;
		}

		// Token: 0x06034F3A RID: 216890 RVA: 0x00D4742C File Offset: 0x00D4562C
		public UniTask Init(UUIItem actor)
		{
			AttributeDynScrollItem.<Init>d__6 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<AttributeDynScrollItem.<Init>d__6>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06034F3B RID: 216891 RVA: 0x00D47478 File Offset: 0x00D45678
		public void Update(IAttributeInfo data, int index)
		{
			if (data.IsLine.GetValueOrDefault())
			{
				base.GetItem(1).SetUIActive(false);
				base.GetItem(2).SetUIActive(false);
				base.GetItem(0).SetUIActive(false);
				UUIItem item = base.GetItem(3);
				item.SetUIActive(true);
				base.GetRootItem().SetHeight(item.GetHeight());
				return;
			}
			this.RoleAttributeItem.Refresh(data);
			this.RefreshBg(data.IsNormalBg);
		}

		// Token: 0x06034F3C RID: 216892 RVA: 0x00D474F8 File Offset: 0x00D456F8
		private void RefreshBg(bool? bNormalBg)
		{
			bool valueOrDefault = bNormalBg.GetValueOrDefault(true);
			base.GetItem(1).SetUIActive(!valueOrDefault);
			base.GetItem(2).SetUIActive(valueOrDefault);
		}

		// Token: 0x06034F3D RID: 216893 RVA: 0x00D4752B File Offset: 0x00D4572B
		public void ClearItem()
		{
			base.Destroy(null);
		}

		// Token: 0x0401E845 RID: 124997
		[Nullable(2)]
		private RoleAttributeItem RoleAttributeItem;

		// Token: 0x0200AFF9 RID: 45049
		[NullableContext(0)]
		private enum ESlotComponent
		{
			// Token: 0x0403696F RID: 223599
			AttributePanel,
			// Token: 0x04036970 RID: 223600
			BgDark,
			// Token: 0x04036971 RID: 223601
			BgNormal,
			// Token: 0x04036972 RID: 223602
			Line
		}
	}
}

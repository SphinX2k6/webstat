using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x02006966 RID: 26982
	[NullableContext(1)]
	[Nullable(0)]
	public class AdamFormationRoleSizeItem : UiPanelBase, IDynamicScrollBaseItem<AdamFormationRoleGroupInfo>
	{
		// Token: 0x06042F21 RID: 274209 RVA: 0x0112FC80 File Offset: 0x0112DE80
		public UniTask Init(UUIItem actor)
		{
			AdamFormationRoleSizeItem.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<AdamFormationRoleSizeItem.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06042F22 RID: 274210 RVA: 0x0112FCCC File Offset: 0x0112DECC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIGridLayout)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
		}

		// Token: 0x06042F23 RID: 274211 RVA: 0x0112FD54 File Offset: 0x0112DF54
		public FVector2D GetItemSize(AdamFormationRoleGroupInfo data)
		{
			if (this.ItemSizeVector == null)
			{
				this.ItemSizeVector = Vector2D.Create();
			}
			if (data.IsTitleType)
			{
				UUIItem item = base.GetItem(2);
				this.ItemSizeVector.Set((double)item.GetWidth(), (double)item.GetHeight());
				return this.ItemSizeVector.ToUeVector2D(false);
			}
			TWeakObjectPtr<UUIItem> rootUIComp = base.GetGridLayout(0).RootUIComp;
			this.ItemSizeVector.Set((double)rootUIComp.Get().GetWidth(), (double)rootUIComp.Get().GetHeight());
			return this.ItemSizeVector.ToUeVector2D(false);
		}

		// Token: 0x06042F24 RID: 274212 RVA: 0x0112FDE8 File Offset: 0x0112DFE8
		public void ClearItem()
		{
		}

		// Token: 0x040254C0 RID: 152768
		[Nullable(2)]
		private Vector2D ItemSizeVector;
	}
}

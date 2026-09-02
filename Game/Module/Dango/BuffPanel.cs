using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Dango
{
	// Token: 0x02005DE1 RID: 24033
	[NullableContext(1)]
	[Nullable(0)]
	internal class BuffPanel : UiPanelBase
	{
		// Token: 0x0603C7E4 RID: 247780 RVA: 0x00F5D120 File Offset: 0x00F5B320
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIMultiTemplateLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.ButtonClick))
			};
		}

		// Token: 0x0603C7E5 RID: 247781 RVA: 0x00F5D1B4 File Offset: 0x00F5B3B4
		private void ButtonClick()
		{
			AttrListScrollData[] dangoShowAttributeList = ModelBase<DangoAbyssModel>.Instance.GetDangoShowAttributeList(this.CurrentData.GetId());
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DangoAbyssAttributeDetailView, dangoShowAttributeList.ToList<AttrListScrollData>(), null);
		}

		// Token: 0x0603C7E6 RID: 247782 RVA: 0x00F5D1ED File Offset: 0x00F5B3ED
		protected override void OnStart()
		{
			this.TagScroller = new GenericLayout<DangoAbyssTagItem, DangoAbyssDefine.DangoAbyssTagData>(base.GetMultiTemplateLayout(1), new Func<DangoAbyssTagItem>(this.CreateTagItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x0603C7E7 RID: 247783 RVA: 0x00F5D220 File Offset: 0x00F5B420
		private DangoAbyssTagItem CreateTagItem()
		{
			return new DangoAbyssTagItem();
		}

		// Token: 0x0603C7E8 RID: 247784 RVA: 0x00F5D227 File Offset: 0x00F5B427
		public void Refresh(AbyssDangoRoleData data)
		{
			this.CurrentData = data;
			this.RefreshTag(data);
		}

		// Token: 0x0603C7E9 RID: 247785 RVA: 0x00F5D238 File Offset: 0x00F5B438
		private void RefreshTag(AbyssDangoRoleData data)
		{
			int id = data.GetId();
			List<DangoAbyssDefine.DangoAbyssTagData> list = ModelBase<DangoAbyssModel>.Instance.GetDangoTagData(id, DangoAbyssDefine.ETagDataGetType.Valid).ToList<DangoAbyssDefine.DangoAbyssTagData>();
			list.Sort((DangoAbyssDefine.DangoAbyssTagData a, DangoAbyssDefine.DangoAbyssTagData b) => b.Value.CompareTo(a.Value));
			GenericLayout<DangoAbyssTagItem, DangoAbyssDefine.DangoAbyssTagData> tagScroller = this.TagScroller;
			if (tagScroller == null)
			{
				return;
			}
			tagScroller.RefreshByData(list, null, false);
		}

		// Token: 0x04022035 RID: 139317
		[Nullable(2)]
		private AbyssDangoRoleData CurrentData;

		// Token: 0x04022036 RID: 139318
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<DangoAbyssTagItem, DangoAbyssDefine.DangoAbyssTagData> TagScroller;
	}
}

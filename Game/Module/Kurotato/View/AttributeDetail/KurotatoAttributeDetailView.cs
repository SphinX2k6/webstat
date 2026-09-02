using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.AttributeDetail
{
	// Token: 0x02005AD6 RID: 23254
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoAttributeDetailView : UiViewBase
	{
		// Token: 0x0603ACB6 RID: 240822 RVA: 0x00EE8D72 File Offset: 0x00EE6F72
		public KurotatoAttributeDetailView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603ACB7 RID: 240823 RVA: 0x00EE8D7C File Offset: 0x00EE6F7C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603ACB8 RID: 240824 RVA: 0x00EE8E08 File Offset: 0x00EE7008
		protected override void OnStart()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnBackButtonClick));
			this.CaptionItem.SetTitleLocalText("PrefabTextItem_1302715335_Text");
			this.CaptionItem.SetHelpCallBack(delegate
			{
				int helpIdAttrInfo = ConfigBase<KurotatoConfig>.Instance.GetHelpIdAttrInfo();
				ControllerBase<HelpController>.Instance.OpenHelpById(helpIdAttrInfo);
			});
			this.AttrLayout = new GenericLayout<KurotatoRoleAttributeItem, IKurotatoRoleSkillInfo>(base.GetVerticalLayout(1), new Func<KurotatoRoleAttributeItem>(this.InitAttrItem), null, false, true);
			this.RefreshAttrList();
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.AttributeComponentEvent, true);
			Singleton<EventSystem>.Instance.Add<IDictionary<int, int>>(EEventName.KurotatoOnPropertyUpdate, new Action<IDictionary<int, int>>(this.OnAttrChanged));
			this.AttrListenDelegate = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCAllAttrChange>(new Action<EKSC_AttrType, int, int>(this.OnKscAttrChanged));
			ModelBase<KurotatoModel>.Instance.BattleData.AssignAllPlayerAttrListen(this.AttrListenDelegate);
		}

		// Token: 0x0603ACB9 RID: 240825 RVA: 0x00EE8EFC File Offset: 0x00EE70FC
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove<IDictionary<int, int>>(EEventName.KurotatoOnPropertyUpdate, new Action<IDictionary<int, int>>(this.OnAttrChanged));
			if (this.AttrListenDelegate != null)
			{
				ModelBase<KurotatoModel>.Instance.BattleData.RemoveAllPlayerAttrListen(this.AttrListenDelegate);
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EKSC_AttrType, int, int>(this.OnKscAttrChanged));
				this.AttrListenDelegate = null;
			}
			this.CaptionItem.Destroy(null);
			if (this.AttrLayout != null)
			{
				this.AttrLayout = null;
			}
		}

		// Token: 0x0603ACBA RID: 240826 RVA: 0x00EE8F75 File Offset: 0x00EE7175
		private void OnAttrChanged(IDictionary<int, int> propertyValues)
		{
			this.RefreshAttrList();
		}

		// Token: 0x0603ACBB RID: 240827 RVA: 0x00EE8F7D File Offset: 0x00EE717D
		private void OnKscAttrChanged(EKSC_AttrType attrType, int oldValue, int newValue)
		{
			this.RefreshAttrList();
		}

		// Token: 0x0603ACBC RID: 240828 RVA: 0x00EE8F88 File Offset: 0x00EE7188
		private void RefreshAttrList()
		{
			KurotatoModel model = ModelBase<KurotatoModel>.Instance;
			List<IKurotatoRoleSkillInfo> data = (from config in ConfigBase<KurotatoConfig>.Instance.GetAllProperty()
			where config.RoleType != 0
			select config).OrderBy((KurotatoProperty config) => config, Comparer<KurotatoProperty>.Create(delegate(KurotatoProperty a, KurotatoProperty b)
			{
				if (a.RoleType != b.RoleType)
				{
					return a.RoleType - b.RoleType;
				}
				if (a.Priority == 0 && b.Priority == 0)
				{
					return a.Id - b.Id;
				}
				int num = a.Priority - b.Priority;
				if (num == 0)
				{
					return a.Id - b.Id;
				}
				return num;
			})).Select(delegate(KurotatoProperty config)
			{
				bool flag = model.IsPropertyLocked(config.Id);
				return new KurotatoRoleSkillInfo
				{
					AttrId = config.Id,
					Value = model.GetPropertyValue(config.Id),
					IsRecommend = false,
					BaseValue = new int?(config.BasicValue),
					IsLocked = new bool?(flag),
					LockedValue = new int?(flag ? model.GetPropertyLockedValue(config.Id) : 0)
				};
			}).ToList<IKurotatoRoleSkillInfo>();
			this.AttrLayout.RefreshByData(data, null, true);
		}

		// Token: 0x0603ACBD RID: 240829 RVA: 0x00EE9041 File Offset: 0x00EE7241
		private KurotatoRoleAttributeItem InitAttrItem()
		{
			return new KurotatoRoleAttributeItem();
		}

		// Token: 0x0603ACBE RID: 240830 RVA: 0x00EE9048 File Offset: 0x00EE7248
		private void OnBackButtonClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x040213A8 RID: 136104
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040213A9 RID: 136105
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<KurotatoRoleAttributeItem, IKurotatoRoleSkillInfo> AttrLayout;

		// Token: 0x040213AA RID: 136106
		[Nullable(2)]
		private FOnKSCAllAttrChange AttrListenDelegate;

		// Token: 0x0200BB01 RID: 47873
		[NullableContext(0)]
		private enum EAttributeView
		{
			// Token: 0x04039B87 RID: 236423
			ItemCaption,
			// Token: 0x04039B88 RID: 236424
			AttributeContent,
			// Token: 0x04039B89 RID: 236425
			ItemAttribute
		}
	}
}

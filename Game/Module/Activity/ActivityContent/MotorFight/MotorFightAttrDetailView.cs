using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066E8 RID: 26344
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorFightAttrDetailView : UiViewBase
	{
		// Token: 0x06041C32 RID: 269362 RVA: 0x010DE57C File Offset: 0x010DC77C
		public MotorFightAttrDetailView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041C33 RID: 269363 RVA: 0x010DE59C File Offset: 0x010DC79C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041C34 RID: 269364 RVA: 0x010DE628 File Offset: 0x010DC828
		protected override UniTask OnBeforeStartAsync()
		{
			MotorFightAttrDetailView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorFightAttrDetailView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041C35 RID: 269365 RVA: 0x010DE66C File Offset: 0x010DC86C
		private List<MotorFightDetailAttrDetailData> GetAttrInfoByType(EMotorFightAttrShowType type)
		{
			List<MotorFightDetailAttrDetailData> result;
			if (this.AttrInfoMap.TryGetValue(type, out result))
			{
				return result;
			}
			if (this.AllAttrInfo.Count == 0)
			{
				this.AllAttrInfo = new List<MotorFightAttrShow>(ConfigBase<MotorFightConfig>.Instance.GetMotorFightAttrShow());
			}
			List<MotorFightDetailAttrDetailData> list = new List<MotorFightDetailAttrDetailData>();
			foreach (MotorFightAttrShow config in this.AllAttrInfo)
			{
				if ((type == EMotorFightAttrShowType.MainGun && config.ShowInMainGun) || (type == EMotorFightAttrShowType.Wingman && config.ShowInWingman) || (type == EMotorFightAttrShowType.Common && config.ShowInCommon))
				{
					MotorFightDetailAttrDetailData item = new MotorFightDetailAttrDetailData
					{
						Type = type,
						Config = config
					};
					list.Add(item);
				}
			}
			this.AttrInfoMap[type] = list;
			return list;
		}

		// Token: 0x06041C36 RID: 269366 RVA: 0x010DE744 File Offset: 0x010DC944
		private void OnTabClickCallBack(EMotorFightAttrShowType type)
		{
			this.TabLayout.SelectGridProxyByKey(type, false);
			List<MotorFightDetailAttrDetailData> attrInfoByType = this.GetAttrInfoByType(type);
			GenericLayout<MotorFightDetailAttrItem, MotorFightDetailAttrDetailData> attrLayout = this.AttrLayout;
			if (attrLayout == null)
			{
				return;
			}
			attrLayout.RefreshByData(attrInfoByType, null, false);
		}

		// Token: 0x06041C37 RID: 269367 RVA: 0x010DE77E File Offset: 0x010DC97E
		private MotorFightAttrTabItem CreateTabItem()
		{
			return new MotorFightAttrTabItem
			{
				OnToggleClickCallBack = new Action<EMotorFightAttrShowType>(this.OnTabClickCallBack)
			};
		}

		// Token: 0x06041C38 RID: 269368 RVA: 0x010DE797 File Offset: 0x010DC997
		private MotorFightDetailAttrItem CreateAttrItem()
		{
			return new MotorFightDetailAttrItem();
		}

		// Token: 0x06041C39 RID: 269369 RVA: 0x010DE79E File Offset: 0x010DC99E
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x04024B07 RID: 150279
		private readonly Dictionary<EMotorFightAttrShowType, List<MotorFightDetailAttrDetailData>> AttrInfoMap = new Dictionary<EMotorFightAttrShowType, List<MotorFightDetailAttrDetailData>>();

		// Token: 0x04024B08 RID: 150280
		private List<MotorFightAttrShow> AllAttrInfo = new List<MotorFightAttrShow>();

		// Token: 0x04024B09 RID: 150281
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024B0A RID: 150282
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<MotorFightAttrTabItem, EMotorFightAttrShowType> TabLayout;

		// Token: 0x04024B0B RID: 150283
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<MotorFightDetailAttrItem, MotorFightDetailAttrDetailData> AttrLayout;

		// Token: 0x0200C721 RID: 50977
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D4DF RID: 251103
			public const int ItemCaption = 0;

			// Token: 0x0403D4E0 RID: 251104
			public const int LayoutAttrInfo = 1;

			// Token: 0x0403D4E1 RID: 251105
			public const int LayoutTab = 2;
		}
	}
}

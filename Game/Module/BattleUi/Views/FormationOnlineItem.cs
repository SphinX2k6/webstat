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
	// Token: 0x0200600E RID: 24590
	[NullableContext(1)]
	[Nullable(0)]
	public class FormationOnlineItem : UiPanelBase
	{
		// Token: 0x0603DF43 RID: 253763 RVA: 0x00FCEB60 File Offset: 0x00FCCD60
		public FormationOnlineItem(UUIItem rootUiItem)
		{
			base.CreateThenShowByResourceIdAsync("UiItem_FigthRoleHeadOnline", rootUiItem, false).Forget();
		}

		// Token: 0x0603DF44 RID: 253764 RVA: 0x00FCEB7C File Offset: 0x00FCCD7C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DF45 RID: 253765 RVA: 0x00FCEC69 File Offset: 0x00FCCE69
		protected override void OnStart()
		{
			this.DisconnectSequencePlayer = new LevelSequencePlayer(base.GetItem(1));
			this.ClearAllHandle();
		}

		// Token: 0x0603DF46 RID: 253766 RVA: 0x00FCEC83 File Offset: 0x00FCCE83
		protected override void OnBeforeDestroy()
		{
			this.DisconnectSequencePlayer.Clear();
			this.DisconnectSequencePlayer = null;
		}

		// Token: 0x0603DF47 RID: 253767 RVA: 0x00FCEC97 File Offset: 0x00FCCE97
		public void SetNameText(string name)
		{
			if (base.InAsyncLoading())
			{
				this.NameHandle = name;
				return;
			}
			this.NameHandle = name;
			this.SetNameTextAsync(name).Forget();
		}

		// Token: 0x0603DF48 RID: 253768 RVA: 0x00FCECBC File Offset: 0x00FCCEBC
		private UniTask SetNameTextAsync(string name)
		{
			FormationOnlineItem.<SetNameTextAsync>d__13 <SetNameTextAsync>d__;
			<SetNameTextAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetNameTextAsync>d__.<>4__this = this;
			<SetNameTextAsync>d__.name = name;
			<SetNameTextAsync>d__.<>1__state = -1;
			<SetNameTextAsync>d__.<>t__builder.Start<FormationOnlineItem.<SetNameTextAsync>d__13>(ref <SetNameTextAsync>d__);
			return <SetNameTextAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DF49 RID: 253769 RVA: 0x00FCED08 File Offset: 0x00FCCF08
		public void SetOnlineNumber(int onlineNumber)
		{
			if (base.InAsyncLoading())
			{
				this.OnlineNumberHandle = new int?(onlineNumber);
				return;
			}
			UUITexture texture = base.GetTexture(2);
			if (onlineNumber < 0)
			{
				texture.SetUIActive(false);
				return;
			}
			texture.SetUIActive(true);
			UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
			defaultInterpolatedStringHandler.AppendLiteral("FormationOnline");
			defaultInterpolatedStringHandler.AppendFormatted<int>(onlineNumber);
			defaultInterpolatedStringHandler.AppendLiteral("PIcon");
			string resourcePath = instance.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear());
			base.SetTextureByPath(resourcePath, texture, null, null);
		}

		// Token: 0x0603DF4A RID: 253770 RVA: 0x00FCED94 File Offset: 0x00FCCF94
		public void SetIsGrayByOtherControl(bool isGray)
		{
			if (base.InAsyncLoading())
			{
				this.IsGrayByOtherControl = isGray;
				return;
			}
			UUITexture texture = base.GetTexture(2);
			UUIItem uuiitem = texture;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(isGray, fcolor);
			UUIText text = base.GetText(3);
			UUIItem uuiitem2 = text;
			fcolor = new FColor?(text.changeColor);
			uuiitem2.SetChangeColor(isGray, fcolor);
		}

		// Token: 0x0603DF4B RID: 253771 RVA: 0x00FCEDEB File Offset: 0x00FCCFEB
		public void SetNetWeak(bool isWeak)
		{
			if (base.InAsyncLoading())
			{
				this.IsWeak = isWeak;
				return;
			}
			base.GetItem(0).SetUIActive(isWeak);
		}

		// Token: 0x0603DF4C RID: 253772 RVA: 0x00FCEE0C File Offset: 0x00FCD00C
		public void RefreshThirdPartyItem(string thirdPartyAccountId)
		{
			if (base.InAsyncLoading())
			{
				this.CurrentThirdPartyAccountId = thirdPartyAccountId;
				return;
			}
			this.CurrentThirdPartyAccountId = thirdPartyAccountId;
			this.RefreshThirdPartyItemAsync(thirdPartyAccountId).Forget();
			this.RefreshPcItem(thirdPartyAccountId);
			if (this.NameHandle != null)
			{
				this.SetNameTextAsync(this.NameHandle).Forget();
			}
		}

		// Token: 0x0603DF4D RID: 253773 RVA: 0x00FCEE5C File Offset: 0x00FCD05C
		private void RefreshPcItem(string thirdPartyAccountId)
		{
			if (ControllerBase<KuroSdkController>.Instance.NeedShowThirdPartyId())
			{
				bool flag = thirdPartyAccountId != string.Empty;
				UUIItem item = base.GetItem(5);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(!flag);
				return;
			}
			else
			{
				UUIItem item2 = base.GetItem(5);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(false);
				return;
			}
		}

		// Token: 0x0603DF4E RID: 253774 RVA: 0x00FCEEAC File Offset: 0x00FCD0AC
		private UniTask RefreshThirdPartyItemAsync(string thirdPartyAccountId)
		{
			FormationOnlineItem.<RefreshThirdPartyItemAsync>d__19 <RefreshThirdPartyItemAsync>d__;
			<RefreshThirdPartyItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshThirdPartyItemAsync>d__.<>4__this = this;
			<RefreshThirdPartyItemAsync>d__.thirdPartyAccountId = thirdPartyAccountId;
			<RefreshThirdPartyItemAsync>d__.<>1__state = -1;
			<RefreshThirdPartyItemAsync>d__.<>t__builder.Start<FormationOnlineItem.<RefreshThirdPartyItemAsync>d__19>(ref <RefreshThirdPartyItemAsync>d__);
			return <RefreshThirdPartyItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DF4F RID: 253775 RVA: 0x00FCEEF7 File Offset: 0x00FCD0F7
		public void SetNetDisconnect(bool isDisconnect)
		{
			if (base.InAsyncLoading())
			{
				this.IsDisconnect = isDisconnect;
				return;
			}
			this.SetDisconnectStatus(isDisconnect);
		}

		// Token: 0x0603DF50 RID: 253776 RVA: 0x00FCEF10 File Offset: 0x00FCD110
		private void SetDisconnectStatus(bool isDisconnect)
		{
			base.GetItem(1).SetUIActive(isDisconnect);
			this.DisconnectSequencePlayer.StopCurrentSequence(false, false);
			if (isDisconnect)
			{
				this.DisconnectSequencePlayer.PlayLevelSequenceByName("AutoLoop", false, null, false);
			}
		}

		// Token: 0x0603DF51 RID: 253777 RVA: 0x00FCEF58 File Offset: 0x00FCD158
		private void ClearAllHandle()
		{
			if (this.NameHandle != null)
			{
				this.SetNameText(this.NameHandle);
				this.NameHandle = null;
			}
			if (this.OnlineNumberHandle != null)
			{
				this.SetOnlineNumber(this.OnlineNumberHandle.Value);
				this.OnlineNumberHandle = null;
			}
			if (this.CurrentThirdPartyAccountId != null)
			{
				this.RefreshThirdPartyItem(this.CurrentThirdPartyAccountId);
				this.CurrentThirdPartyAccountId = null;
			}
			base.GetItem(0).SetUIActive(this.IsWeak);
			this.SetDisconnectStatus(this.IsDisconnect);
			this.SetIsGrayByOtherControl(this.IsGrayByOtherControl);
		}

		// Token: 0x04022BF4 RID: 142324
		[Nullable(2)]
		private string NameHandle;

		// Token: 0x04022BF5 RID: 142325
		private int? OnlineNumberHandle;

		// Token: 0x04022BF6 RID: 142326
		[Nullable(2)]
		private string CurrentThirdPartyAccountId;

		// Token: 0x04022BF7 RID: 142327
		private bool IsGrayByOtherControl;

		// Token: 0x04022BF8 RID: 142328
		private bool IsWeak;

		// Token: 0x04022BF9 RID: 142329
		private bool IsDisconnect;

		// Token: 0x04022BFA RID: 142330
		[Nullable(2)]
		private LevelSequencePlayer DisconnectSequencePlayer;

		// Token: 0x0200C0AA RID: 49322
		[NullableContext(0)]
		private enum EFormationOnlineItem
		{
			// Token: 0x0403B51C RID: 242972
			NetWeakItem,
			// Token: 0x0403B51D RID: 242973
			PanelDisconnect,
			// Token: 0x0403B51E RID: 242974
			OnlineNumberTexture,
			// Token: 0x0403B51F RID: 242975
			NameText,
			// Token: 0x0403B520 RID: 242976
			ThirdPartyTexture,
			// Token: 0x0403B521 RID: 242977
			PcItem
		}
	}
}

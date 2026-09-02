using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x0200577C RID: 22396
	public class DeviceInfoView : UiViewBase
	{
		// Token: 0x06038FE9 RID: 233449 RVA: 0x00E710F0 File Offset: 0x00E6F2F0
		[NullableContext(1)]
		public DeviceInfoView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038FEA RID: 233450 RVA: 0x00E710FC File Offset: 0x00E6F2FC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x06038FEB RID: 233451 RVA: 0x00E71158 File Offset: 0x00E6F358
		protected override UniTask OnBeforeStartAsync()
		{
			DeviceInfoView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DeviceInfoView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038FEC RID: 233452 RVA: 0x00E7119C File Offset: 0x00E6F39C
		private UniTask InitCaptionItem()
		{
			DeviceInfoView.<InitCaptionItem>d__6 <InitCaptionItem>d__;
			<InitCaptionItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCaptionItem>d__.<>4__this = this;
			<InitCaptionItem>d__.<>1__state = -1;
			<InitCaptionItem>d__.<>t__builder.Start<DeviceInfoView.<InitCaptionItem>d__6>(ref <InitCaptionItem>d__);
			return <InitCaptionItem>d__.<>t__builder.Task;
		}

		// Token: 0x06038FED RID: 233453 RVA: 0x00E711DF File Offset: 0x00E6F3DF
		private void InitScrollView()
		{
			this.ScrollView = new GenericScrollViewNew<DeviceInfoItem, DeviceInfoItemData>(base.GetScrollViewWithScrollbar(1), new Func<DeviceInfoItem>(this.CreateDeviceInfoItem), null, false, null);
		}

		// Token: 0x06038FEE RID: 233454 RVA: 0x00E71202 File Offset: 0x00E6F402
		[NullableContext(1)]
		private DeviceInfoItem CreateDeviceInfoItem()
		{
			return new DeviceInfoItem();
		}

		// Token: 0x06038FEF RID: 233455 RVA: 0x00E71209 File Offset: 0x00E6F409
		protected override void OnStart()
		{
			this.RefreshDeviceInfo();
		}

		// Token: 0x06038FF0 RID: 233456 RVA: 0x00E71214 File Offset: 0x00E6F414
		private void RefreshDeviceInfo()
		{
			IReadOnlyList<DeviceInfo> configList = ConfigDeviceInfoAll.GetConfigList(true);
			if (configList == null)
			{
				return;
			}
			Dictionary<EDeviceInfo, Func<ValueTuple<string, bool>>> dictionary = this.CreateFunctionMap();
			List<DeviceInfoItemData> list = new List<DeviceInfoItemData>();
			foreach (DeviceInfo deviceInfo in configList)
			{
				Func<ValueTuple<string, bool>> getInfoFunction;
				if (dictionary.TryGetValue((EDeviceInfo)deviceInfo.Id, out getInfoFunction))
				{
					DeviceInfoItemData item = new DeviceInfoItemData(deviceInfo.Id, deviceInfo.Name, deviceInfo.LowTips, getInfoFunction);
					list.Add(item);
				}
			}
			GenericScrollViewNew<DeviceInfoItem, DeviceInfoItemData> scrollView = this.ScrollView;
			if (scrollView == null)
			{
				return;
			}
			scrollView.RefreshByData(list.ToList<DeviceInfoItemData>(), null, true);
		}

		// Token: 0x06038FF1 RID: 233457 RVA: 0x00E712C0 File Offset: 0x00E6F4C0
		[return: Nullable(new byte[]
		{
			1,
			1,
			0,
			1
		})]
		private Dictionary<EDeviceInfo, Func<ValueTuple<string, bool>>> CreateFunctionMap()
		{
			Dictionary<EDeviceInfo, Func<ValueTuple<string, bool>>> dictionary = new Dictionary<EDeviceInfo, Func<ValueTuple<string, bool>>>();
			dictionary.Add(EDeviceInfo.CPU, () => Singleton<GameSettingsDeviceRender>.Instance.GetCPUInformation());
			dictionary.Add(EDeviceInfo.GPU, () => Singleton<GameSettingsDeviceRender>.Instance.GetGPUInformation());
			dictionary.Add(EDeviceInfo.GraphicDriverVersion, () => Singleton<GameSettingsDeviceRender>.Instance.GetGraphicDriverVersion());
			dictionary.Add(EDeviceInfo.GraphicAPI, () => Singleton<GameSettingsDeviceRender>.Instance.GetGraphicAPI());
			dictionary.Add(EDeviceInfo.Memory, () => Singleton<GameSettingsDeviceRender>.Instance.GetMemoryInformation());
			dictionary.Add(EDeviceInfo.VideoMemory, () => Singleton<GameSettingsDeviceRender>.Instance.GetVideoMemoryInformation());
			dictionary.Add(EDeviceInfo.GameInstallPath, () => Singleton<GameSettingsDeviceRender>.Instance.GetGameInstallPath());
			dictionary.Add(EDeviceInfo.WindowsVersion, () => Singleton<GameSettingsDeviceRender>.Instance.GetWindowsVersion());
			return dictionary;
		}

		// Token: 0x0402071D RID: 132893
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<DeviceInfoItem, DeviceInfoItemData> ScrollView;

		// Token: 0x0402071E RID: 132894
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0200B817 RID: 47127
		public class EComponent
		{
			// Token: 0x04038F1B RID: 233243
			public const int CaptionItem = 0;

			// Token: 0x04038F1C RID: 233244
			public const int ScrollView = 1;

			// Token: 0x04038F1D RID: 233245
			public const int InfoItem = 2;
		}
	}
}

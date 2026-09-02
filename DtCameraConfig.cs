using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.Camera;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02000E06 RID: 3590
[NullableContext(1)]
[Nullable(0)]
internal class DtCameraConfig
{
	// Token: 0x06005452 RID: 21586 RVA: 0x000CBC1A File Offset: 0x000C9E1A
	public DtCameraConfig(UDataTable dataTable)
	{
	}

	// Token: 0x170005B0 RID: 1456
	// (get) Token: 0x06005453 RID: 21587 RVA: 0x000CBC51 File Offset: 0x000C9E51
	public UDataTable DataTable { get; } = dataTable;

	// Token: 0x06005454 RID: 21588 RVA: 0x000CBC5C File Offset: 0x000C9E5C
	public unsafe void SetToConfigs(Dictionary<int, CameraConfig> subConfigs, Dictionary<int, CameraConfig> focusConfigs, Dictionary<int, CameraConfig> accompanyConfigs, string platformCheckKey)
	{
		TArray<SCameraConfig> cameraConfigList = ControllerBase<CameraController>.Instance.GetCameraConfigList(this.DataTable);
		int num = cameraConfigList.Num();
		for (int i = 0; i < num; i++)
		{
			CameraConfig cameraConfig = new CameraConfig(cameraConfigList.Get(i));
			FieldInfo field = typeof(CameraConfig).GetField(platformCheckKey);
			if (!(field == null) && (bool)field.GetValue(cameraConfig))
			{
				if (cameraConfig.Tag == null || cameraConfig.Tag.Value.TagName == FName.NAME_None)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Camera;
					ELogAuthor author = ELogAuthor.LJM;
					string message = "独有镜头配置不允许Tag为None";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DT", this.DataTable.GetOuter());
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					int num2 = cameraConfig.Tag.Value.TagId();
					if (cameraConfig.Type == EFightCameraType.子镜头)
					{
						if (!subConfigs.TryAdd(num2, cameraConfig))
						{
							Log instance2 = Singleton<Log>.Instance;
							ELogModule module2 = ELogModule.Camera;
							ELogAuthor author2 = ELogAuthor.LJM;
							string message2 = "[子镜头]独有镜头配置不允许重复的Tag";
							<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("DT", this.DataTable.GetOuter());
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Tag", cameraConfig.Tag.Value.TagName);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Type", cameraConfig.Type);
							instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
						}
						else
						{
							this.SubValidKeys.Add(num2);
						}
					}
					else if (cameraConfig.Type == EFightCameraType.锁定目标镜头)
					{
						if (!focusConfigs.TryAdd(num2, cameraConfig))
						{
							Log instance3 = Singleton<Log>.Instance;
							ELogModule module3 = ELogModule.Camera;
							ELogAuthor author3 = ELogAuthor.LJM;
							string message3 = "[锁定目标镜头]独有镜头配置不允许重复的Tag";
							<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("DT", this.DataTable.GetOuter());
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Tag", cameraConfig.Tag.Value.TagName);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Type", cameraConfig.Type);
							instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
						}
						else
						{
							this.FocusValidKeys.Add(num2);
						}
					}
					else if (cameraConfig.Type == EFightCameraType.伴随目标镜头)
					{
						if (!accompanyConfigs.TryAdd(num2, cameraConfig))
						{
							Log instance4 = Singleton<Log>.Instance;
							ELogModule module4 = ELogModule.Camera;
							ELogAuthor author4 = ELogAuthor.LJM;
							string message4 = "[伴随目标镜头]独有镜头配置不允许重复的Tag";
							<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("DT", this.DataTable.GetOuter());
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Tag", cameraConfig.Tag.Value.TagName);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("Type", cameraConfig.Type);
							instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
						}
						else
						{
							this.AccompanyValidKeys.Add(num2);
						}
					}
				}
			}
		}
	}

	// Token: 0x06005455 RID: 21589 RVA: 0x000CBFA0 File Offset: 0x000CA1A0
	[Conditional("DEBUG")]
	private void PrintToScreen(string content)
	{
		if (!this.EnablePrintLogToScreen)
		{
			return;
		}
		UWorld world = GlobalData.World;
		UWorld uworld = (world != null) ? world.GetWorld() : null;
		if (uworld == null)
		{
			return;
		}
		UKismetSystemLibrary.PrintString(uworld, content, true, true, new FLinearColor?(new FLinearColor(1f, 0f, 0f, 1f)), 20f);
	}

	// Token: 0x06005456 RID: 21590 RVA: 0x000CBFF8 File Offset: 0x000CA1F8
	public void RemoveFromConfigs(Dictionary<int, CameraConfig> subConfigs, Dictionary<int, CameraConfig> focusConfigs, Dictionary<int, CameraConfig> accompanyConfigs)
	{
		foreach (int key in this.SubValidKeys)
		{
			subConfigs.Remove(key);
		}
		foreach (int key2 in this.FocusValidKeys)
		{
			focusConfigs.Remove(key2);
		}
		foreach (int key3 in this.AccompanyValidKeys)
		{
			accompanyConfigs.Remove(key3);
		}
		this.SubValidKeys.Clear();
		this.FocusValidKeys.Clear();
		this.AccompanyValidKeys.Clear();
	}

	// Token: 0x0400195E RID: 6494
	public int ReferenceCount;

	// Token: 0x0400195F RID: 6495
	public HashSet<int> SubValidKeys = new HashSet<int>();

	// Token: 0x04001960 RID: 6496
	public HashSet<int> FocusValidKeys = new HashSet<int>();

	// Token: 0x04001961 RID: 6497
	public HashSet<int> AccompanyValidKeys = new HashSet<int>();

	// Token: 0x04001962 RID: 6498
	private readonly bool EnablePrintLogToScreen = true;
}

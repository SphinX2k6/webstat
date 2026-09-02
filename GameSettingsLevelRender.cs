using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02000E99 RID: 3737
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GameSettingsLevelRender : Singleton<GameSettingsLevelRender>
{
	// Token: 0x06005BE8 RID: 23528 RVA: 0x0016F6A1 File Offset: 0x0016D8A1
	protected override bool OnInit()
	{
		this.SetLevelRenderSettingsStat = Stat.Create("Render_LevelRenderSettingsManager_SetLevelRenderSettings", "", "");
		this.RevertLevelRenderSettingsStat = Stat.Create("Render_LevelRenderSettingsManager_RevertLevelRenderSettings", "", "");
		return true;
	}

	// Token: 0x06005BE9 RID: 23529 RVA: 0x0016F6D8 File Offset: 0x0016D8D8
	public unsafe void SetLevelRenderSettings()
	{
		InstanceDungeon? instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
		if (((instanceDungeon != null) ? instanceDungeon.GetValueOrDefault().RenderSettings() : null) != null)
		{
			instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
			foreach (int key in instanceDungeon.Value.RenderSettings().Keys)
			{
				instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
				int num;
				string text;
				if (instanceDungeon.Value.RenderSettings().TryGetValue(key, out num) && this.LevelRenderSettingCommands.TryGetValue(key, out text))
				{
					UObject world = GlobalData.World;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
					defaultInterpolatedStringHandler.AppendFormatted(text);
					defaultInterpolatedStringHandler.AppendLiteral(" ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(num);
					UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Render;
					ELogAuthor author = ELogAuthor.ZYT;
					string message = "进入特殊副本-调整渲染参数";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("设置", text);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("为", num);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
		}
	}

	// Token: 0x06005BEA RID: 23530 RVA: 0x0016F840 File Offset: 0x0016DA40
	public unsafe void RevertLevelRenderSetting()
	{
		InstanceDungeon? instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
		if (((instanceDungeon != null) ? instanceDungeon.GetValueOrDefault().RenderSettings() : null) != null)
		{
			instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
			foreach (int key in instanceDungeon.Value.RenderSettings().Keys)
			{
				float num;
				string text;
				if (this.LevelRenderSettingCommandsDefaultValue.TryGetValue(key, out num) && this.LevelRenderSettingCommands.TryGetValue(key, out text))
				{
					UObject world = GlobalData.World;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
					defaultInterpolatedStringHandler.AppendFormatted(text);
					defaultInterpolatedStringHandler.AppendLiteral(" ");
					defaultInterpolatedStringHandler.AppendFormatted<float>(num);
					UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Render;
					ELogAuthor author = ELogAuthor.ZYT;
					string message = "退出特殊副本-调整渲染参数";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("设置", text);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("为", num);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
		}
	}

	// Token: 0x04002C19 RID: 11289
	private readonly Dictionary<int, string> LevelRenderSettingCommands = new Dictionary<int, string>
	{
		{
			1,
			"r.Shadow.EnableCSMStable"
		},
		{
			2,
			"r.MotionBlur.OuterScale"
		},
		{
			3,
			"r.AllowHardwareOcclusion"
		},
		{
			4,
			"r.Kuro.HideLandscape"
		}
	};

	// Token: 0x04002C1A RID: 11290
	private readonly Dictionary<int, float> LevelRenderSettingCommandsDefaultValue = new Dictionary<int, float>
	{
		{
			1,
			1f
		},
		{
			2,
			1f
		},
		{
			3,
			1f
		},
		{
			4,
			0f
		}
	};

	// Token: 0x04002C1B RID: 11291
	[Nullable(2)]
	public Stat SetLevelRenderSettingsStat;

	// Token: 0x04002C1C RID: 11292
	[Nullable(2)]
	public Stat RevertLevelRenderSettingsStat;
}

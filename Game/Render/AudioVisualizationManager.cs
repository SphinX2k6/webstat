using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.AudioVisualization;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004737 RID: 18231
	[NullableContext(1)]
	[Nullable(0)]
	public class AudioVisualizationManager : IStaticVariableResetter
	{
		// Token: 0x0602F52C RID: 193836 RVA: 0x00B38FE8 File Offset: 0x00B371E8
		public static AudioVisualizationManager Get()
		{
			if (AudioVisualizationManager.Singleton == null)
			{
				AudioVisualizationManager.Singleton = new AudioVisualizationManager();
				AudioVisualizationManager.Singleton.Initialize();
			}
			return AudioVisualizationManager.Singleton;
		}

		// Token: 0x0602F52D RID: 193837 RVA: 0x00B3900A File Offset: 0x00B3720A
		protected void LoadAssets()
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<PDA_AudioVisualizationGlobalConfigs_C>("/Game/Aki/Audio/AudioVisualization/Data/DA_AudioVisualizationGlobalConfigs.DA_AudioVisualizationGlobalConfigs", delegate([Nullable(2)] PDA_AudioVisualizationGlobalConfigs_C result, string _)
			{
				if (result == null || !result.IsValid())
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Render;
					ELogAuthor author = ELogAuthor.LSY;
					string message = "音频可视化未找到全局配置文件";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", "/Game/Aki/Audio/AudioVisualization/Data/DA_AudioVisualizationGlobalConfigs.DA_AudioVisualizationGlobalConfigs");
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				this.GlobalConfig = result;
				this.MaterialParametersCollectionFile = result.MPCFile;
				if (this.MaterialParametersCollectionFile == null || !this.MaterialParametersCollectionFile.IsValid())
				{
					Singleton<Log>.Instance.Error(ELogModule.Render, ELogAuthor.LSY, "音频可视化缺失MPC文件", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}, 100, "js_undefined");
		}

		// Token: 0x0602F52E RID: 193838 RVA: 0x00B3902F File Offset: 0x00B3722F
		protected void Initialize()
		{
			this.InstanceActors = new Dictionary<string, AudioVisualizationInstanceBase>();
			this.LoadAssets();
		}

		// Token: 0x0602F52F RID: 193839 RVA: 0x00B39042 File Offset: 0x00B37242
		public void Register(AudioVisualizationInstanceBase instance)
		{
			this.InstanceActors[instance.Identifier] = instance;
			instance.ActorEndPlayCallback = delegate(AudioVisualizationInstanceBase ins)
			{
				this.Unregister(ins);
			};
			instance.Start();
		}

		// Token: 0x0602F530 RID: 193840 RVA: 0x00B3906E File Offset: 0x00B3726E
		public void Unregister(AudioVisualizationInstanceBase instance)
		{
			this.InstanceActors.Remove(instance.Identifier);
			instance.End();
		}

		// Token: 0x0602F531 RID: 193841 RVA: 0x00B39088 File Offset: 0x00B37288
		public void NotifyCallBackToAll([Nullable(2)] UAkCallbackInfo callbackInfo, EAkCallbackType callbackType, string state)
		{
			foreach (KeyValuePair<string, AudioVisualizationInstanceBase> keyValuePair in this.InstanceActors)
			{
				keyValuePair.Value.CallBack(callbackInfo, callbackType, state);
			}
		}

		// Token: 0x0602F532 RID: 193842 RVA: 0x00B390E4 File Offset: 0x00B372E4
		public void Tick(double deltaSeconds)
		{
		}

		// Token: 0x0602F533 RID: 193843 RVA: 0x00B390E6 File Offset: 0x00B372E6
		static AudioVisualizationManager()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(AudioVisualizationManager.CreateStaticDefaultValue), new Action(AudioVisualizationManager.ResetStaticDefaultValue));
		}

		// Token: 0x0602F534 RID: 193844 RVA: 0x00B39105 File Offset: 0x00B37305
		public static void CreateStaticDefaultValue()
		{
			AudioVisualizationManager.Singleton = null;
			AudioVisualizationManager.StatTick = Stat.Create("AudioVisualizationManager.Tick", "", "");
		}

		// Token: 0x0602F535 RID: 193845 RVA: 0x00B39126 File Offset: 0x00B37326
		public static void ResetStaticDefaultValue()
		{
			AudioVisualizationManager.Singleton = null;
			AudioVisualizationManager.StatTick = null;
		}

		// Token: 0x0401AF1D RID: 110365
		[Nullable(2)]
		private static AudioVisualizationManager Singleton;

		// Token: 0x0401AF1E RID: 110366
		[Nullable(2)]
		public PDA_AudioVisualizationGlobalConfigs_C GlobalConfig;

		// Token: 0x0401AF1F RID: 110367
		[Nullable(2)]
		public UMaterialParameterCollection MaterialParametersCollectionFile;

		// Token: 0x0401AF20 RID: 110368
		private static Stat StatTick;

		// Token: 0x0401AF21 RID: 110369
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected Dictionary<string, AudioVisualizationInstanceBase> InstanceActors;
	}
}

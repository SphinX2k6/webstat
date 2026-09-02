using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x0200490D RID: 18701
	[NullableContext(1)]
	[Nullable(0)]
	public class PhysicsAssetLoader
	{
		// Token: 0x06030DF9 RID: 200185 RVA: 0x00C1BAFC File Offset: 0x00C19CFC
		public bool SetDataAndLoadAsset([Nullable(2)] CharacterActorComponent actorComp, PhysicsAssetConfig config, Action callBack)
		{
			this.LoadSuccess = false;
			if (config.BoneNamesLength == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Character;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "该角色未在角色物理资产配置表中配置骨骼名 /Config/j.角色物理资产";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("默认值Id", config.Id);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			string path = config.PhysicsAssetPath;
			if (string.IsNullOrEmpty(path))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Character;
				ELogAuthor author2 = ELogAuthor.LJM;
				string message2 = "该角色未在角色物理资产配置表中骨骼路径配置为空 /Config/j.角色物理资产";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("默认值Id", config.Id);
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			this.ActorComp = actorComp;
			Singleton<ResourceSystem>.Instance.LoadAsync<UPhysicsAsset>(path, delegate([Nullable(2)] UPhysicsAsset result, string _)
			{
				if (result == null)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Character;
					ELogAuthor author3 = ELogAuthor.LJM;
					string message3 = "该角色未在角色物理资产配置表中骨骼路径配置加载失败 /Config/j.角色物理资产";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("path", path);
					instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				}
				this.ActorComp.Actor.Mesh.SetPhysicsAsset(result, true);
				this.LoadSuccess = true;
				callBack();
			}, 100, "js_undefined");
			int boneNamesLength = config.BoneNamesLength;
			for (int i = 0; i < boneNamesLength; i++)
			{
				this.BoneNames.Add(config.BoneNames(i));
			}
			return true;
		}

		// Token: 0x06030DFA RID: 200186 RVA: 0x00C1BBFD File Offset: 0x00C19DFD
		public void ClearData()
		{
			this.BoneNames.Clear();
			this.ActorComp = null;
			this.LoadSuccess = false;
		}

		// Token: 0x0401C17D RID: 115069
		public List<string> BoneNames = new List<string>();

		// Token: 0x0401C17E RID: 115070
		public bool LoadSuccess;

		// Token: 0x0401C17F RID: 115071
		[Nullable(2)]
		public CharacterActorComponent ActorComp;
	}
}

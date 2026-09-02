using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;

// Token: 0x02003499 RID: 13465
[NullableContext(1)]
public interface IMapLoad
{
	// Token: 0x0601C6AF RID: 116399
	UniTask Load(SceneInformation sceneInformation);
}

﻿//////////////////////////////////////////////////////
// MK Glow Pipeline Properties                      //
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2020 All rights reserved.            //
//////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Glow
{
    #if UNITY_2018_3_OR_NEWER
    #if ENABLE_VR
    using XRSettings = UnityEngine.XR.XRSettings;
    #endif
    #endif

    /// <summary>
    /// Contains all PipelineProperties used in MK Glow
    /// </summary>
    internal static class PipelineProperties
    {
        //For even super large displays preserve some extra memory to prevent erros and gc.
        internal static readonly int renderBufferSize = 15;
        internal static bool scriptableRenderPipelineActive{ get { return UnityEngine.Rendering.GraphicsSettings.renderPipelineAsset != null; } }
        #if UNITY_2018_3_OR_NEWER
        #if ENABLE_VR
        internal static bool xrEnabled { get{ return XRSettings.enabled; } }
        internal static bool singlePassStereoDoubleWideEnabled { get{ return XRSettings.enabled && XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.SinglePass; } }
        internal static bool singlePassStereoInstancedEnabled { get{ return XRSettings.enabled && (XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.SinglePassInstanced || XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.SinglePassMultiview); } }
        #else
        internal static bool xrEnabled { get{ return false; } }
        internal static bool singlePassStereoDoubleWideEnabled { get{ return false; } }
        internal static bool singlePassStereoInstancedEnabled { get{ return false; } }
        #endif
        #else
        //No proper way of detecting stereo rendering mode so just return false
        internal static bool xrEnabled { get{ return false; } }
        internal static bool singlePassStereoDoubleWideEnabled { get{ return false; } }
        internal static bool singlePassStereoInstancedEnabled { get{ return false; } }
        #endif

        /// <summary>
        /// Shader PipelineProperties as IDs
        /// </summary>
        internal static class ShaderProperties
        {
            /// <summary>
            /// Representation of a render property based on unity version
            /// The id of the given name will be autogenerated
            /// </summary>
            internal class DefaultProperty
            {
                protected string _name;
                internal string name
                {
                    get{return _name;}
                }
                #if UNITY_2017_3_OR_NEWER
                protected int _id;
                internal int id
                {
                    get{return _id;}
                }
                #else
                internal string id
                {
                    get{return _name;}
                }
                #endif

                internal DefaultProperty(string name)
                {
                    this._name = name;
                    #if UNITY_2017_3_OR_NEWER
                    this._id = Shader.PropertyToID(name);
                    #endif
                }
            }

            /// <summary>
            /// Constant args buffer property, mostly used for storing floats based on the positon in the args buffer
            /// </summary>
            internal sealed class CBufferProperty : DefaultProperty
            {
                private int _index;
                /// <summary>
                /// Position in the buffer
                /// </summary>
                /// <value></value>
                internal int index
                {
                    get{return _index;}
                }
                /// <summary>
                /// Length of the content in bytes
                /// </summary>
                private int _size;
                internal int size
                {
                    get{return _size;}
                }
                internal CBufferProperty(string name, int index, int size) : base ("")
                {
                    this._name = name;
                    #if UNITY_2017_3_OR_NEWER
                    this._id = Shader.PropertyToID(name);
                    #endif
                    this._index = index;
                    this._size = size;
                }
            }

            //Main, Bloom
            internal static readonly CBufferProperty screenSize                      = new CBufferProperty("_DisplaySize", 0, 2);
            internal static readonly CBufferProperty singlePassStereoScale           = new CBufferProperty("_SinglePassStereoScale", 65, 1);
            internal static readonly CBufferProperty viewMatrix                      = new CBufferProperty("_ViewMatrix", 49, 16);
            internal static readonly DefaultProperty cArgBuffer                      = new DefaultProperty("_CArgBuffer");
            internal static readonly DefaultProperty sourceTex                       = new DefaultProperty("_SourceTex");
            internal static readonly DefaultProperty targetTex                       = new DefaultProperty("_TargetTex");
            internal static readonly DefaultProperty copyTargetTex                   = new DefaultProperty("_CopyTargetTex");
            internal static readonly DefaultProperty bloomTex                        = new DefaultProperty("_BloomTex");
            internal static readonly DefaultProperty bloomTargetTex                  = new DefaultProperty("_BloomTargetTex");
            internal static readonly CBufferProperty bloomSpread                     = new CBufferProperty("_BloomSpread", 3, 1);
            internal static readonly CBufferProperty bloomThreshold                  = new CBufferProperty("_BloomThreshold", 0, 2);
            internal static readonly CBufferProperty lumaScale                       = new CBufferProperty("_LumaScale", 2, 1);
            internal static readonly CBufferProperty bloomIntensity                  = new CBufferProperty("_BloomIntensity", 4, 1);
            internal static readonly CBufferProperty blooming                        = new CBufferProperty("_Blooming", 5, 1);
            internal static readonly DefaultProperty higherMipBloomTex               = new DefaultProperty("_HigherMipBloomTex");
            internal static readonly CBufferProperty resolutionScale                 = new CBufferProperty("_ResolutionScale", 38, 2);
            internal static readonly CBufferProperty renderTargetSize                = new CBufferProperty("_RenderTargetSize", 38, 2);

            //Lens Surface
            internal static readonly DefaultProperty lensSurfaceDirtTex              = new DefaultProperty("_LensSurfaceDirtTex");
            internal static readonly DefaultProperty lensSurfaceDiffractionTex       = new DefaultProperty("_LensSurfaceDiffractionTex");
            internal static readonly CBufferProperty lensSurfaceDirtIntensity        = new CBufferProperty("_LensSurfaceDirtIntensity", 6, 1);
            internal static readonly CBufferProperty lensSurfaceDiffractionIntensity = new CBufferProperty("_LensSurfaceDiffractionIntensity", 7, 1);
            internal static readonly CBufferProperty lensSurfaceDirtTexST            = new CBufferProperty("_LensSurfaceDirtTex_ST", 44, 4);

            //Lens Flare
            internal static readonly CBufferProperty lensFlareThreshold              = new CBufferProperty("_LensFlareThreshold", 8, 2);
            internal static readonly CBufferProperty lensFlareGhostParams            = new CBufferProperty("_LensFlareGhostParams", 10, 4);
            internal static readonly CBufferProperty lensFlareHaloParams             = new CBufferProperty("_LensFlareHaloParams", 14, 3);
            internal static readonly DefaultProperty lensFlareTex                    = new DefaultProperty("_LensFlareTex");
            internal static readonly DefaultProperty lensFlareTargetTex              = new DefaultProperty("_LensFlareTargetTex");
            internal static readonly CBufferProperty lensFlareSpread                 = new CBufferProperty("_LensFlareSpread", 17, 1);
            internal static readonly CBufferProperty lensFlareChromaticAberration    = new CBufferProperty("_LensFlareChromaticAberration", 18, 1);
            internal static readonly DefaultProperty lensFlareColorRamp              = new DefaultProperty("_LensFlareColorRamp");

            //Glare
            internal static readonly CBufferProperty glareThreshold                  = new CBufferProperty("_GlareThreshold", 19, 2);
            internal static readonly CBufferProperty glareBlend                      = new CBufferProperty("_GlareBlend", 33, 1);
            internal static readonly CBufferProperty glareGlobalIntensity            = new CBufferProperty("_GlareGlobalIntensity", 33, 1);
            internal static readonly CBufferProperty glareIntensity                  = new CBufferProperty("_GlareIntensity", 34, 4);
            internal static readonly CBufferProperty glareScattering                 = new CBufferProperty("_GlareScattering", 21, 4);
            internal static readonly CBufferProperty glareDirection01                = new CBufferProperty("_GlareDirection01", 25, 4);
            internal static readonly CBufferProperty glareDirection23                = new CBufferProperty("_GlareDirection23", 29, 4);
            internal static readonly CBufferProperty glareOffset                     = new CBufferProperty("_GlareOffset", 40, 4);
            internal static readonly DefaultProperty glare0Tex                       = new DefaultProperty("_Glare0Tex");
            internal static readonly DefaultProperty glare0TargetTex                 = new DefaultProperty("_Glare0TargetTex");
            internal static readonly DefaultProperty glare1Tex                       = new DefaultProperty("_Glare1Tex");
            internal static readonly DefaultProperty glare1TargetTex                 = new DefaultProperty("_Glare1TargetTex");
            internal static readonly DefaultProperty glare2Tex                       = new DefaultProperty("_Glare2Tex");
            internal static readonly DefaultProperty glare2TargetTex                 = new DefaultProperty("_Glare2TargetTex");
            internal static readonly DefaultProperty glare3Tex                       = new DefaultProperty("_Glare3Tex");
            internal static readonly DefaultProperty glare3TargetTex                 = new DefaultProperty("_Glare3TargetTex");
        }

        /// <summary>
        /// CommandBuffer PipelineProperties as strings
        /// </summary>
        internal static class CommandBufferProperties
        {
            //Main
            internal static readonly string commandBufferName         = "MK Glow";
            internal static readonly string selectiveRenderBuffer     = "_SelectiveRenderBuffer";
            internal static readonly string bloomDownsampleBuffer     = "_BloomDownsampleBuffer";
            internal static readonly string bloomUpsampleBuffer       = "_BloomUpsampleBuffer";
            internal static readonly string sourceBuffer              = "_SourceBuffer";

            //Glare   
            internal static readonly string glareDownsampleBuffer0    = "GlareDownsampleBuffer0";
            internal static readonly string glareDownsampleBuffer1    = "GlareDownsampleBuffer1";
            internal static readonly string glareDownsampleBuffer2    = "GlareDownsampleBuffer2";
            internal static readonly string glareDownsampleBuffer3    = "GlareDownsampleBuffer3";
            internal static readonly string glareUpsampleBuffer0      = "GlareUpsampleBuffer0";
            internal static readonly string glareUpsampleBuffer1      = "GlareUpsampleBuffer1";
            internal static readonly string glareUpsampleBuffer2      = "GlareUpsampleBuffer2";
            internal static readonly string glareUpsampleBuffer3      = "GlareUpsampleBuffer3";

            //Lens Flare
            internal static readonly string lensFlareDownsampleBuffer = "LensFlareDownsampleBuffer";
            internal static readonly string lensFlareUpsampleBuffer   = "LensFlareUpsampleBuffer";

            //Buffer Samples
            internal static readonly string sampleDownsample          = "Downsample";
            internal static readonly string samplePreSample           = "Presample";
            internal static readonly string sampleUpsample            = "Upsample";
            internal static readonly string sampleComposite           = "Composite";
            internal static readonly string sampleCreateBuffers       = "Create Mip Buffers";
            internal static readonly string sampleClearBuffers        = "Clear Mip Buffers";
            internal static readonly string sampleSetup               = "Setup Constant Buffer";
            internal static readonly string sampleCopySource          = "Copy Source";
            internal static readonly string sampleReplacement         = "Render Replacement";
            internal static readonly string samplePrepare             = "Prepare";
        }
    }
}
